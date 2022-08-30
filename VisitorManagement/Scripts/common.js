var defaultProgressTitle = "Test";


let stopAjaxStartShowProgress = false;
let stopAjaxStopHideProgress = false;
const notifyDataCallbacks = [];
var lastProgressRequestID;
var lockDownLog = "";
var threatLevelLog = "";
var commandStatusPublisher = [];
var commandStatusFilterType = { Operation: "Operation", Key1: "Key1", PnlNo: "PnlNo", ParentId: "ParentId" };
var commandStatusProgressRequestIdList = [];
var commandStatusDangerButtonList = [];

const clearSessions = url => $.post({
    url,
    contentType: "application/json; charset=utf-8"
});

const addUTCOffsetWithDateString = (dateString) => {
    if (dateString) {
        const timeoffset = (- new Date().getTimezoneOffset());
        const utcTime = new Date(dateString);
        let localTime = new Date(utcTime);
        localTime.setMinutes(utcTime.getMinutes() + timeoffset);
        return localTime.toLocaleString();
    } else {
        return dateString;
    }
};

const CodedSubMessageID = Object.freeze({
    None: 0,
    Started: 1, //(Abort)
    InProgress: 2, //(InProgress)
    Success: 3, //(automati close)
    Failed: 4, // (change abort to close)
    NetworkFail: 5, // (change abort to close)
    PartialSuccess: 6,
    LDOutput: 7,// Lockdown Output
    TLOutput: 8, // Threat Level Output
    LDOutputFailed: 9, // Failed Lockdown Output
    TLOutputFailed: 10 // Failed Threat Level Output
});

const handleProgress = (codedSubMessageID, progressMessage, webAlertData) => {
    if (codedSubMessageID === CodedSubMessageID.Success
        || codedSubMessageID === CodedSubMessageID.LDOutput
        || codedSubMessageID === CodedSubMessageID.TLOutput) {
        if (getPendingCommandCount() <= 0) {
            //hideProgress();
            updateSuccess(webAlertData);
        } else {
            updatePartialSuccess(progressMessage);
        }
        if (codedSubMessageID === CodedSubMessageID.LDOutput) { //Lockdown Output
            loadLockdownAreas();
            writeLockdownOutput(progressMessage);
        }
        if (codedSubMessageID === CodedSubMessageID.TLOutput) { //ThreatLevel Output
            loadThreatLevels();
            loadLockdownAreas(false);
            writeThreatLevelOutput(progressMessage);
        }
        //applyLockdownThreatlevelMarquee();
    }
    else if (codedSubMessageID === CodedSubMessageID.Started || codedSubMessageID === CodedSubMessageID.InProgress) {
        if (!progressMessage) {
            progressMessage = codedSubMessageID === CodedSubMessageID.Started ? 'Started' : 'In Progress';
        }
        updateProgress(progressMessage);
    }
    else if (codedSubMessageID === CodedSubMessageID.Failed
        || codedSubMessageID === CodedSubMessageID.NetworkFail
        || codedSubMessageID === CodedSubMessageID.LDOutputFailed
        || codedSubMessageID === CodedSubMessageID.TLOutputFailed) {
        if (!progressMessage) {
            progressMessage = codedSubMessageID === CodedSubMessageID.NetworkFail ? 'Network Failure Occured' : commandExecutionFailedText;
        }
        if (getPendingCommandCount() <= 0) {
            let decodedError = progressMessage.replaceAll('<u>', '').replaceAll('</u>', '').replaceAll('<br>', '').replaceAll('\t', '');
            updateError(decodedError, webAlertData);
        } else {
            updatePartialError(progressMessage);
        }
        if (codedSubMessageID === CodedSubMessageID.LDOutputFailed) { //Lockdown Output Failed
            writeLockdownOutput(progressMessage);
        }
        if (codedSubMessageID === CodedSubMessageID.TLOutputFailed) { //ThreatLevel Output Failed
            writeThreatLevelOutput(progressMessage);
        }
    }
    else if (codedSubMessageID === CodedSubMessageID.LDOutput) {//Lockdown Output
        writeLockdownOutput(progressMessage);
    }
    else if (codedSubMessageID === CodedSubMessageID.TLOutput) {//ThreatLevel Output
        writeThreatLevelOutput(progressMessage);
    }

    if ($("#lockdown-areas-threat-level-apb-area-modal").is(":visible")) {

        let outputVal = $(".progress-modal-content #title").attr("output");
        if (outputVal == CodedSubMessageID.LDOutput)
            lockDownLog += progressMessage + '<hr/>';
        else if (outputVal == CodedSubMessageID.TLOutput)
            threatLevelLog += progressMessage + '<hr/>';
    }
};

const notifyAlertData = function (webAlertData) {
    try {
        const { ProgressMessage, CodedSubMessageID: codedSubMessageID, ProgressRequestID } = JSON.parse(webAlertData).DataObject;

        //console.log(JSON.parse(webAlertData).DataObject); // TODO: DELETE

        if (codedSubMessageID === CodedSubMessageID.Success
            || codedSubMessageID === CodedSubMessageID.LDOutput
            || codedSubMessageID === CodedSubMessageID.TLOutput) {

            applyLockdownThreatlevelMarquee();
        }

        if ($('#progress-modal').attr("progressRequestId") === ProgressRequestID
            || $('#ldcLog').is(':visible') && $('#ldcLog .modal-footer').attr("progress-request-id") === ProgressRequestID) { // || !ProgressRequestID) {
            //progressRequestId is mandatory 
            if (codedSubMessageID === CodedSubMessageID.Success
                || codedSubMessageID === CodedSubMessageID.LDOutput
                || codedSubMessageID === CodedSubMessageID.TLOutput
                || codedSubMessageID === CodedSubMessageID.Failed
                || codedSubMessageID === CodedSubMessageID.NetworkFail
                || codedSubMessageID === CodedSubMessageID.LDOutputFailed
                || codedSubMessageID === CodedSubMessageID.TLOutputFailed) {

                decrementPendingCommandCount();
            }
            handleProgress(codedSubMessageID, ProgressMessage, webAlertData);

            if (getPendingCommandCount() <= 0) {
                for (var i = 0; i < notifyDataCallbacks.length; i++) {
                    notifyDataCallbacks[i](webAlertData);
                }
            }
        }
    } catch (e) {
        console.error(e);
    }
};

//Lockdown Command Status Update
function lockdownCommandStatusUpdate(data) {
    //data = data.filter(x => new Date(x.LastUpdate) > new Date(new Date().getTime() - (24 * 60 * 60 * 1000)));
    if ($("#lockdown-areas-threat-level-apb-area-modal").is(":visible")) {
        loadLockdownAreas(false);
        for (let i = 0; i < data.length; i++) {
            let bColor = "#FFD580";
            let color = data[i]["Key2"] == 0 ? "#dc3545" : "#00488e";
            let btnText = data[i]["Key2"] == 0 ? "Deactivating" : "Activating";
            switch (parseInt(data[i]["CommandState"])) {
                case 0:
                    $($(`.card-lockdown-area #${data[i]["Key3"]} :button`)[0]).html("Pending")
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 1:
                    $($(`.card-lockdown-area #${data[i]["Key3"]} :button`)[0]).html("Started")
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 2:
                    $($(`.card-lockdown-area #${data[i]["Key3"]} :button`)[0]).html(btnText)
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 3:
                    $($(`.card-lockdown-area #${data[i]["Key3"]} :button`)[0]).html("Failed")
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 4:
                    $($(`.card-lockdown-area #${data[i]["Key3"]} :button`)[0]).html(btnText)
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 5:
                    $($(`.card-lockdown-area #${data[i]["Key3"]} :button`)[0]).html(btnText)
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 6:
                    $($(`.card-lockdown-area #${data[i]["Key3"]} :button`)[0]).html("Failed")
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
            }
            setCommandStatusProgressRequestId(`ldcs-btn-${data[i]["Key3"]}`);
        }
    }
}

//ThreatLevel Command Status Update
function threatLevelCommandStatusUpdate(data) {
    //data = data.filter(x => new Date(x.LastUpdate) > new Date(new Date().getTime() - (24 * 60 * 60 * 1000)));
    if ($("#lockdown-areas-threat-level-apb-area-modal").is(":visible")) {
        loadThreatLevels(false);
        for (let i = 0; i < data.length; i++) {
            let bColor = "#FFD580";
            let color = data[i]["Key2"] == 0 ? "#dc3545" : "#00488e";
            let btnText = data[i]["Key2"] == 0 ? "Deactivating" : "Activating";
            switch (parseInt(data[i]["CommandState"])) {
                case 0:
                    $($(`.card-threat-level #${data[i]["Key3"]} :button`)[0]).html("Pending")
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 1:
                    $($(`.card-threat-level #${data[i]["Key3"]} :button`)[0]).html("Started")
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 2:
                    $($(`.card-threat-level #${data[i]["Key3"]} :button`)[0]).html(btnText)
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 3:
                    $($(`.card-threat-level #${data[i]["Key3"]} :button`)[0]).html("Failed")
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 4:
                    $($(`.card-threat-level #${data[i]["Key3"]} :button`)[0]).html(btnText)
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 5:
                    $($(`.card-threat-level #${data[i]["Key3"]} :button`)[0]).html(btnText)
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
                case 6:
                    $($(`.card-threat-level #${data[i]["Key3"]} :button`)[0]).html("Failed")
                        .css("background-color", bColor).css("border-color", bColor).css("color", color);
                    break;
            }
            setCommandStatusProgressRequestId(`tlcs-btn-${data[i]["Key3"]}`);
        }
    }
}

function isCommandExecutionFailed(key, id) {
    $.ajax({
        type: "POST",
        url: baseUrlCAWebService + '/IsCommandExecutionFailed',
        data: "{companyId: " + companyId + ", key: " + key + ", id: " + id + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: true,
        async: true,
        success: function (msg) {
            let data = null;
            if (msg.d)
                data = JSON.parse(msg.d);
            if (data) {
                if (data.isChildCommandStateFailed) {
                    if (key == 0) {
                        $(`#ldcs-btn-${id}`).addClass('text-danger');
                        commandStatusDangerButtonList.indexOf(`ldcs-btn-${id}`) == -1 && commandStatusDangerButtonList.push(`ldcs-btn-${id}`);
                    }
                    else if (key == 1) {
                        $(`#tlcs-btn-${id}`).addClass('text-danger');
                        commandStatusDangerButtonList.indexOf(`tlcs-btn-${id}`) == -1 && commandStatusDangerButtonList.push(`tlcs-btn-${id}`);
                    }
                }
                else {
                    if (key == 0) {
                        $(`#ldcs-btn-${id}`).removeClass('text-danger');
                        commandStatusDangerButtonList.indexOf(`ldcs-btn-${id}`) != -1 && commandStatusDangerButtonList.splice(commandStatusDangerButtonList.indexOf(`ldcs-btn-${id}`), 1);
                    }
                    else if (key == 1) {
                        $(`#tlcs-btn-${id}`).removeClass('text-danger');
                        commandStatusDangerButtonList.indexOf(`tlcs-btn-${id}`) != -1 && commandStatusDangerButtonList.splice(commandStatusDangerButtonList.indexOf(`tlcs-btn-${id}`), 1);
                    }
                }
            }
        },
        error: function (data, status, jqXHR) {
            showAlert("Error", data.responseText);
        }
    });
}

function setCommandStatusProgressRequestId(id) {
    let item = commandStatusProgressRequestIdList.filter(x => x.id === id);
    if (item.length > 0)
        $(`#${id}`).removeAttr('progress-request-id').attr('progress-request-id', item[0].value);
}

if (typeof site_origin !== 'undefined') {
    import(site_origin + '/Scripts/pubsub.js').then((module) => {
        const pubsub = module.pubsub;
        pubsub.subscribe("onNotifyData", notifyAlertData);
        //Add Lockdown/ThreatLevel Publisher & Subscribe // Operation = 29 -> LockDown, Key1 = 0 -> LockdownDoor, Key1 = 1 -> ThreatLevel
        commandStatusPublisher.push(["onLockdownCommandStatusUpdate", { [commandStatusFilterType.Operation]: 29, [commandStatusFilterType.Key1]: 0, [commandStatusFilterType.PnlNo]: 0, [commandStatusFilterType.ParentId]: 0 }]);
        commandStatusPublisher.push(["onThreatLevelCommandStatusUpdate", { [commandStatusFilterType.Operation]: 29, [commandStatusFilterType.Key1]: 1, [commandStatusFilterType.PnlNo]: 0, [commandStatusFilterType.ParentId]: 0 }]);
        pubsub.subscribe("onLockdownCommandStatusUpdate", lockdownCommandStatusUpdate);
        pubsub.subscribe("onThreatLevelCommandStatusUpdate", threatLevelCommandStatusUpdate);
    });
}

function getCommandStateText(CommandState) {
    var CommandStateText = "";
    switch (CommandState) {
        case 0:
            CommandStateText = "Pending";
            break;
        case 1:
            CommandStateText = "Started";
            break;
        case 2:
            CommandStateText = "Executing";
            break;
        case 3:
            CommandStateText = "Failed";
            break;
        case 4:
            CommandStateText = "Generic Command Executing";
            break;
        case 5:
            CommandStateText = "Generic child command executed";
            break;
        case 6:
            CommandStateText = "Generic command Failed";
    }

    return CommandStateText;
}

function onLockdownDetailsClick(id, forceOpenModal = false) {
    $('#title').text(string_LockDownAreas);
    $('#ldcLog .modal-footer').text('');
    getLastLockdownThreatLevelExecutionResultById(0, id, forceOpenModal);
}

function onThreatLevelDetailsClick(id, forceOpenModal = false) {
    $('#title').text(string_Threat_Level);
    $('#ldcLog .modal-footer').text('');
    getLastLockdownThreatLevelExecutionResultById(1, id, forceOpenModal);
}

function onLockdownThreatLevelRefreshClick(key, id) {
    showProgress($('#title').text());
    getLastLockdownThreatLevelExecutionResultById(key, id, false, true);
}

const getLastLockdownThreatLevelExecutionResultById = (key, id, forceOpenModal = false, autoUpdate = false) => {
    if (!forceOpenModal) {
        $.ajax({
            type: "POST",
            url: baseUrlCAWebService + '/GetLastLockdownThreatLevelExecutionResultById',
            data: "{companyId: " + companyId + ", key: " + key + ", id: " + id + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            async: true,
            success: function (msg) {
                hideProgress();
                let data = null;
                if (msg.d)
                    data = JSON.parse(msg.d);
                if (data) {
                    //let failedLocks = JSON.stringify(data.FailedLocks);
                    let childMetadataStr = '';
                    if (Array.isArray(data.ChildMetadata))
                        childMetadataStr = JSON.stringify(data.ChildMetadata[0]);

                    let showLastUpdate = data.IsCommunHistoryData ? '' : 'd-none';
                    let details = `<u class='font-weight-bold'>${data.Title}</u><span class='ml-3 ${showLastUpdate}'>Last executed at ${data.LastUpdate}</span>`;
                    if (data.IsChildCommandStateFailed) {
                        details += `<span class='float-right pb-1'><button class='btn btn-success' onclick='onReExecuteClick(${data.Output}, ${childMetadataStr}, ${id}, ${data.key2})'>Re-execute</button></span>`;
                    }
                    else if (!data.IsCommunHistoryData) {
                        details += `<span class='float-right pb-1'><a href="javascript:void(0)" onclick='onLockdownThreatLevelRefreshClick(${key}, ${id})'><i style="font-size: 18px;" class="fas fa-sync-alt" title="Refresh"></i></a></span>`;
                    }
                    details += loadGridsByStatus(data.LocksStatus);
                    if (data.Output == CodedSubMessageID.LDOutput) {
                        $("#ldcLogModalTitle").text("Lockdown Area Command Status");
                        $("#ldcLogModalBody").html(details);
                        $('#ldcLog').attr("key-id", `${0}-${id}`);
                        if (autoUpdate && !$('#ldcLog').is(':visible')) {
                            return;
                        }
                        jQuery('#ldcLog').modal('show', { backdrop: 'static' });
                        $('#ldcLog .modal-footer').removeAttr("progress-request-id").attr("progress-request-id", $(`#ldcs-btn-${id}`).attr("progress-request-id"));
                    }
                    else if (data.Output == CodedSubMessageID.TLOutput) {
                        $("#ldcLogModalTitle").text("Threat Level Command Status");
                        $("#ldcLogModalBody").html(details);
                        $('#ldcLog').attr("key-id", `${1}-${id}`);
                        if (autoUpdate && !$('#ldcLog').is(':visible')) {
                            return;
                        }
                        jQuery('#ldcLog').modal('show', { backdrop: 'static' });
                        $('#ldcLog .modal-footer').removeAttr("progress-request-id").attr("progress-request-id", $(`#tlcs-btn-${id}`).attr("progress-request-id"));
                    }
                }
                else {
                    $('#ldcLog').modal('hide');
                    alert("Command status not found.");
                }
            },
            error: function (data, status, jqXHR) {
                hideProgress();
                showAlert("Error", data.responseText);
            }
        });
    }
    else {
        if (key == 0) {
            $("#ldcLogModalTitle").text("Lockdown Area Command Status");
            $("#ldcLogModalBody").html('Loading command status...');
            $('#ldcLog').attr("key-id", `${0}-${id}`);
            jQuery('#ldcLog').modal('show', { backdrop: 'static' });
            $('#ldcLog .modal-footer').removeAttr("progress-request-id").attr("progress-request-id", $(`#ldcs-btn-${id}`).attr("progress-request-id"));
        }
        else if (key == 1) {
            $("#ldcLogModalTitle").text("Threat Level Command Status");
            $("#ldcLogModalBody").html('Loading command status...');
            $('#ldcLog').attr("key-id", `${1}-${id}`);
            jQuery('#ldcLog').modal('show', { backdrop: 'static' });
            $('#ldcLog .modal-footer').removeAttr("progress-request-id").attr("progress-request-id", $(`#tlcs-btn-${id}`).attr("progress-request-id"));
        }
        setTimeout(() => getLastLockdownThreatLevelExecutionResultById(key, id, false, true), 3000);
    }
};

function loadGridsByStatus(locksStatus) {
    let notCompleted = locksStatus.filter(x => !x.isSuccess);
    let completed = locksStatus.filter(x => x.isSuccess);
    let details = '';
    if (notCompleted.length > 0) {
        details += "<table class='table table-bordered' id='ldtl-cs-not-completed'>";
        details += '<thead><th>Reader Name</th><th>Status</th></thead>';
        details += '<tbody>';
        for (var i = 0; i < notCompleted.length; i++) {
            details += "<tr class='ldtl-row'>";
            details += `<td style='width: 700px;'>${notCompleted[i].readerName}</td>`;
            details += getColorStatus(notCompleted[i].status);
            details += "</tr>";
        }
        details += "</tbody></table>";
    }
    if (completed.length > 0) {
        details += "<div class='font-weight-bold'>Completed</div>";
        details += "<table class='table table-bordered' id='ldtl-cs-completed'>";
        details += '<thead><th>Reader Name</th><th>Status</th></thead>';
        details += '<tbody>';
        for (var i = 0; i < completed.length; i++) {
            details += "<tr class='ldtl-row'>";
            details += `<td style='width: 700px;'>${completed[i].readerName}</td>`;
            details += getColorStatus(completed[i].status);
            details += "</tr>";
        }
        details += "</tbody></table>";
    }

    return details;
}

function getColorStatus(status) {
    switch (status) {
        case "Executing":
            return `<td class='text-primary'>${status}</td>`;
        case "Failed":
            return `<td class='text-danger'>${status}</td>`;
        case "Success":
        case "PartialSuccess":
            return `<td class='text-success'>${status}</td>`;
        default:
            return `<td>${status}</td>`;
    }
}

function onReExecuteClick(output, childMetadata, id, key2) { // id = Lockdown/ThreatLevel ID, key2 = 0 -> Deactivate, key2 = 1 -> Activate

    showConfirm(string_Confirmation, 'Do you want to re-execute?', function () {
        stopAjaxStartShowProgress = stopAjaxStopHideProgress = true;
        if (output == CodedSubMessageID.LDOutput) {
            showProgress(string_LockDownAreas, undefined, undefined, timeoutMillisecondsDefault, undefined, undefined);
            doRequestLockDownCallback(key2 === 1 ? true : false, id, true, null, childMetadata, function () {
                hideProgress();
                $('#title').text(string_LockDownAreas);
                $(".progress-modal-content #title").attr("output", `${CodedSubMessageID.LDOutput}`);

                commandStatusProgressRequestIdList = commandStatusProgressRequestIdList.filter(x => x.id != `ldcs-btn-${id}`);
                commandStatusProgressRequestIdList.push({ id: `ldcs-btn-${id}`, value: lastProgressRequestID });
                $(`#ldcs-btn-${id}`).removeAttr('progress-request-id').attr('progress-request-id', lastProgressRequestID);
                onLockdownDetailsClick(id, true);
            });
        } else if (output == CodedSubMessageID.TLOutput) {
            showProgress(string_Threat_Level, undefined, undefined, timeoutMillisecondsDefault, undefined, undefined);
            doRequestThreatLevelCallback(id, key2 === 1 ? true : false, null, childMetadata, function () {
                hideProgress();
                $('#title').text(string_Threat_Level);
                $(".progress-modal-content #title").attr("output", `${CodedSubMessageID.TLOutput}`);

                commandStatusProgressRequestIdList = commandStatusProgressRequestIdList.filter(x => x.id != `tlcs-btn-${id}`);
                commandStatusProgressRequestIdList.push({ id: `tlcs-btn-${id}`, value: lastProgressRequestID });
                $(`#tlcs-btn-${id}`).removeAttr('progress-request-id').attr('progress-request-id', lastProgressRequestID);
                onThreatLevelDetailsClick(id, true);
            });
        }
    });
}

(function Progress(global) {
    const $progressModal = $('#progress-modal'),
        $progressContentElement = $progressModal.children(),
        $titleElement = $('#title'),
        $loaderContainer = $('#loader-container'),
        $progressTextElement = $('#progress-text-element'),
        $footer = $('#progress-modal-footer'),
        $abortButton = $('#abort-button'),
        $closeButton = $('#close-button'),
        $detailsLink = $('#btn-progress-success-details');

    let abortTimeoutID, abortOrTimeOutCB, closeTimeoutID, closeCB, timeoutMS, webAlertData, comDevices, pendingCommandCount;

    const setProgressRequestIdAttr = () => clearProgressRequestIdAttr().attr('progressRequestId', lastProgressRequestID);
    const setTitle = title => $titleElement.text(title ? title : defaultProgressTitle);
    const showAbortIf = canAbort => {
        if (canAbort) {
            showAbort();
        }
    };
    const showClose = () => {
        $abortButton.hide();
        $closeButton.show();
        $footer.css('display', 'flex');
    };
    const showAbort = () => {
        $closeButton.hide();
        $abortButton.show();
        $footer.css('display', 'flex');
    };
    const hideAbortButton = () => {
        $abortButton.hide();
        if ($footer.children('button:visible').length === 0) {
            $footer.css('display', 'none');
        }
    };
    const hideCloseButton = () => {
        $closeButton.hide();
        if ($footer.children('button:visible').length === 0) {
            $footer.css('display', 'none');
        }
    };
    const updateTimeout = () => {
        executeAbortOrTimeoutCallBack();
        clearTimers();
        clearAbortOrTimeoutCallback();
        hideLoader();
        setTimeoutText(timeoutText);
        showClose();
        adjustPosition();
        clearProgressRequestIdAttr();
        //showLockdownControlStatus();
    };
    const showLockdownControlStatus = () => {
        if ($("#lockdown-areas-threat-level-apb-area-modal").is(":visible")) {

            let commandId = parseInt($("#progress-modal-parent-command-id-element").text()) || 0;
            $.ajax({
                type: "POST",
                url: baseUrlCAWebService + '/GetCommunDataByCommandId',
                data: "{commandId: " + commandId + ", companyId: " + companyId + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                async: true,
                success: function (msg) {
                    let data = JSON.parse(msg.d);
                    if (data.Output == CodedSubMessageID.LDOutput) {
                        writeLockdownOutput(data.Message);
                        lockDownLog += data.Message + '<hr/>';
                    }
                    else if (data.Output == CodedSubMessageID.TLOutput) {
                        writeThreatLevelOutput(data.Message);
                        threatLevelLog += data.Message + '<hr/>';
                    }
                },
                error: function (data, status, jqXHR) {
                    showAlert("Error", data.responseText);
                }
            });
        }
    };
    const onCloseShowLockdownControlStatus = () => {
        //if ($loaderContainer.is(":visible"))
        //    showLockdownControlStatus();
    };
    const updateError = (err, wAD) => {
        clearTimers();
        clearAbortOrTimeoutCallback();
        hideLoader();
        setErrorText(err);
        showClose();
        initializeDetatilsLink(wAD);
        adjustPosition();
        clearProgressRequestIdAttr();
        clearCommandStatusProgressRequestIdAttr();
    };
    const updatePartialError = (progoressMessage) => {
        //setErrorText(`${stringCommand} ${comDevices.length - pendingCommandCount} ${stringFailed}`);
        setErrorText(progoressMessage);
    };
    const updateSuccess = wAD => {
        clearTimers();
        clearAbortOrTimeoutCallback();
        hideLoader();
        //setSuccessText(commandExecutedText);      
        setSuccessText($titleElement.text() + ' completed');
        showClose();
        initializeDetatilsLink(wAD);
        adjustPosition();
        clearProgressRequestIdAttr();
        clearCommandStatusProgressRequestIdAttr();
    };
    const updatePartialSuccess = progoressMessage => {
        //setSuccessText(`${stringCommand} ${comDevices.length - pendingCommandCount} ${stringExecuted}`);  
        setSuccessText(progoressMessage);
    };
    const hideDetailsLink = () => $detailsLink.hide();
    const showDetailsLink = () => $detailsLink.show();
    const clearWebAlertData = () => webAlertData = null;
    const setWebAlertData = (wAD) => webAlertData = wAD;
    const initializeDetatilsLink = (wAD) => {
        try {
            if (wAD) {
                const wad = JSON.parse(wAD);
                const codedMessage = JSON.parse(wad.DataObject.CodedMessageStr);
                if (wad && codedMessage && codedMessage.filter(cm => cm.ComPort && cm.ComPortAddress && cm.CompanyId && cm.Operation).length && visibleDetailsLinkOnProgressModal.toLowerCase() == 'true') {
                    setWebAlertData(wad);
                    showDetailsLink();
                }
            }
        } catch (e) {
            alert(e);
        }
    };
    const setComDevices = (comDevs) => {
        comDevices = comDevs;
        pendingCommandCount = comDevices ? comDevices.length : 0;
    };
    const getPendingCommandCount = () => pendingCommandCount;
    const decrementPendingCommandCount = () => --pendingCommandCount;
    $detailsLink.click(showProgresDetailsModal);

    const setTimeoutMilliSeconds = (timeout) => {
        timeoutMS = timeout;
    };
    const clearTimeoutMilliSeconds = (timeout) => {
        timeoutMS = null;
    };
    const setAbortOrTimeoutCallback = (callback) => {
        if ($.isFunction(callback)) {
            abortOrTimeOutCB = callback;
        }
        if ($.isNumeric(timeoutMS)) abortTimeoutID = setTimeout(updateTimeout, timeoutMS);
    };
    const resetTimer = () => {
        if ($.isNumeric(timeoutMS)) {
            clearTimeout(abortTimeoutID);
            abortTimeoutID = setTimeout(updateTimeout, timeoutMS);
        }
    };
    const setCloseCallback = (callback) => {
        if ($.isFunction(callback)) {
            closeCB = callback;
            //if ($.isNumeric(timeout)) closeTimeoutID = setTimeout(hideModal, timeout);
        }
    };
    const setProgressIf = txt => {
        if (txt) setProgressText(txt);
    };
    const hideProgressText = () => $progressTextElement.hide();
    const setProgressText = txt => setText(txt, 'text-dark');
    const setErrorText = err => setText(err, 'text-danger');
    const setTimeoutText = err => setText(err, 'text-warning');
    const setSuccessText = txt => setText(txt, 'text-success');
    const setText = (txt, className) => {
        $progressTextElement
            .removeClass('text-dark text-danger text-warning text-success')
            .addClass(className)
            .text(txt)
            .show();
        $('#ldcLog .modal-footer')
            .removeClass('text-dark text-danger text-warning text-success')
            .addClass(className)
            .html('<span class="font-weight-bold text-dark"><img id="ldtl-spin-img" alt="" src="/Images/loader.gif" width="20"/> Progress: </span>' + txt)
            .show();
    };
    const adjustPosition = () => {
        const top = Math.max($(window).height() / 2 - $progressContentElement[0].offsetHeight / 2, 0);
        $progressContentElement.css('margin-top', top);
    };
    const showModal = () => $progressModal.show();
    const hideFooter = () => $footer.css('display', 'none');;
    const clearTimers = () => {
        clearTimeout(abortTimeoutID);
        abortTimeoutID = null;
        clearTimeout(closeTimeoutID);
        closeTimeoutID = null;
    };
    const clearProgressRequestIdAttr = () => $progressModal.removeAttr('progressRequestId');
    const clearCommandStatusProgressRequestIdAttr = () => {
        $("#ldtl-spin-img").hide();
        commandStatusProgressRequestIdList = commandStatusProgressRequestIdList.filter(x => x.value != $('#ldcLog .modal-footer').attr('progress-request-id'));
        $('#ldcLog .modal-footer').removeAttr('progress-request-id');
    };
    const clearAbortOrTimeoutCallback = () => abortOrTimeOutCB = null;
    const clearCloseCallback = () => closeCB = null;
    const executeAbortOrTimeoutCallBack = () => {
        try {
            if ($.isFunction(abortOrTimeOutCB)) {
                const temp = abortOrTimeOutCB;
                clearAbortOrTimeoutCallback();
                temp();
            }
        }
        finally {
            clearAbortOrTimeoutCallback();
        }
    };
    const runCloseCallBack = () => {
        try {
            if ($.isFunction(closeCB)) {
                const temp = closeCB;
                clearCloseCallback();
                temp();
            }
        }
        finally {
            clearAbortOrTimeoutCallback();
        }
    };
    const abortHandler = () => {
        clearTimers();
        executeAbortOrTimeoutCallBack();
        hideModal();
    };
    const closeAction = () => {
        //if ($.isFunction(clCallback)) clCallback();
        runCloseCallBack();
    };
    const showLoader = () => $loaderContainer.show();
    const hideLoader = () => $loaderContainer.hide();
    const hideModal = () => {
        progressLog('hideModal()');
        clearTimeoutMilliSeconds();
        clearTimers();
        clearAbortOrTimeoutCallback();
        clearProgressRequestIdAttr();
        $progressModal.hide();
        closeAction();
    };
    const hideModalFromDetailsLink = () => {
        progressLog('hideModalFromDetailsLink()');
        clearTimeoutMilliSeconds();
        clearTimers();
        clearAbortOrTimeoutCallback();
        clearProgressRequestIdAttr();
        $progressModal.hide();
    };
    const isProgressOpen = () => {
        const result = $.isNumeric(timeoutMS);
        progressLog(`isProgressOpen: ${result}`);
        return result;
    };
    $abortButton.click(abortHandler);
    $closeButton.click(onCloseShowLockdownControlStatus).click(hideModal);
    function showProgresDetailsModal() {
        try {
            hideModalFromDetailsLink();
            $('#progressDetailsModalTemplate').html('');
            $('#progressDetailsModalTemplate').load(`${BASE_URL}/progress-details-modal.html`, () => {
                $('#progress-details-modal').modal('show', { backdrop: 'static' });
                $('#progress-details-modal').on('shown.bs.modal', async function () {
                    const dataObject = webAlertData.DataObject;
                    //const dataObject = getSampleDataObject();
                    const codedMessage = JSON.parse(dataObject.CodedMessageStr);
                    console.log(dataObject);
                    console.log(codedMessage);
                    const result = await postAsync(`${baseUrlCAWebService}/GetProgressDetails`, {
                        dataObject: dataObject
                    }, null, false);
                    const $tbody = $('#tbl-progress-details > tbody');
                    result.forEach(e => {
                        $tbody.append(`
                                    <tr>
                                        <td>${e.PanelName}</td>
                                        <td>${e.Gateway}</td>
                                        <td>${e.Operation}</td>
                                        <td>${e.Status}</td>
                                    </tr>
                                  `);
                    });
                    $('#progress-details-modal').on('hidden.bs.modal', function (e) {
                        runCloseCallBack();
                    });
                });
            });
        } catch (e) {
            alert(e);
        }
        return false;
    }
    function getSampleDataObject() {
        return {
            "SignalRClientID": "13aca499-6220-46c3-9147-333ee5b5f652",
            "ProgressRequestID": "89c1f061-d318-42ba-8525-6360702f440a",
            "CodedSubMessageID": 3,
            "ProgressMessage": "Send Firmware and Data To Selected Lock(s)",
            "CompanyId": 60557,
            "MACAddress": "0080A3E3AC96",
            "CodedMessageId": 10301,
            "CodedMessageStr": "[{\"Id\":3350,\"PnlNo\":1,\"Operation\":1,\"IsDelete\":false,\"Key1\":1,\"Key2\":0,\"Key3\":-1,\"Key4\":-1,\"Key5\":-1,\"TimStamp\":\"2021-03-24T18:09:44.747\",\"UTCExecTime\":0,\"MetadataType\":\"CardAccess.Common.CommunicationMetadata\",\"Metadata\":\"<CommunicationMetadata xmlns:xsi=\\\"http://www.w3.org/2001/XMLSchema-instance\\\" xmlns:xsd=\\\"http://www.w3.org/2001/XMLSchema\\\"><RequireDownload>true</RequireDownload><UpdateType>0</UpdateType><Counter>0</Counter><JSONString>{}</JSONString><SignalRClientID>13aca499-6220-46c3-9147-333ee5b5f652</SignalRClientID><ProgressRequestID>89c1f061-d318-42ba-8525-6360702f440a</ProgressRequestID></CommunicationMetadata>\",\"ComPort\":1,\"CommandState\":2,\"CompanyId\":60591,\"OperationalMode\":2,\"Priority\":99,\"ComPortAddress\":1,\"ComportAddrType\":10,\"MACAddress\":\"0080A38B3493\",\"FailureReason\":\"\",\"RetryCounter\":0,\"LastUpdate\":\"2021-03-24T14:09:44.857\",\"PickedForProcessing\":1,\"ParentId\":0,\"IsParentCommand\":false,\"IsChildCommand\":true},{\"Id\":3351,\"PnlNo\":2,\"Operation\":1,\"IsDelete\":false,\"Key1\":1,\"Key2\":0,\"Key3\":-1,\"Key4\":-1,\"Key5\":-1,\"TimStamp\":\"2021-03-24T18:09:44.8\",\"UTCExecTime\":0,\"MetadataType\":\"CardAccess.Common.CommunicationMetadata\",\"Metadata\":\"<CommunicationMetadata xmlns:xsi=\\\"http://www.w3.org/2001/XMLSchema-instance\\\" xmlns:xsd=\\\"http://www.w3.org/2001/XMLSchema\\\"><RequireDownload>true</RequireDownload><UpdateType>0</UpdateType><Counter>0</Counter><JSONString>{}</JSONString><SignalRClientID>13aca499-6220-46c3-9147-333ee5b5f652</SignalRClientID><ProgressRequestID>89c1f061-d318-42ba-8525-6360702f440a</ProgressRequestID></CommunicationMetadata>\",\"ComPort\":1,\"CommandState\":2,\"CompanyId\":60591,\"OperationalMode\":2,\"Priority\":99,\"ComPortAddress\":2,\"ComportAddrType\":10,\"MACAddress\":\"0080A3E3AC96\",\"FailureReason\":\"\",\"RetryCounter\":0,\"LastUpdate\":\"2021-03-24T14:09:44.857\",\"PickedForProcessing\":1,\"ParentId\":3350,\"IsParentCommand\":false,\"IsChildCommand\":true},{\"Id\":3352,\"PnlNo\":3,\"Operation\":1,\"IsDelete\":false,\"Key1\":1,\"Key2\":0,\"Key3\":-1,\"Key4\":-1,\"Key5\":-1,\"TimStamp\":\"2021-03-24T18:09:44.857\",\"UTCExecTime\":0,\"MetadataType\":\"CardAccess.Common.CommunicationMetadata\",\"Metadata\":\"<CommunicationMetadata xmlns:xsi=\\\"http://www.w3.org/2001/XMLSchema-instance\\\" xmlns:xsd=\\\"http://www.w3.org/2001/XMLSchema\\\"><RequireDownload>true</RequireDownload><UpdateType>0</UpdateType><Counter>0</Counter><JSONString>{}</JSONString><SignalRClientID>13aca499-6220-46c3-9147-333ee5b5f652</SignalRClientID><ProgressRequestID>89c1f061-d318-42ba-8525-6360702f440a</ProgressRequestID></CommunicationMetadata>\",\"ComPort\":1,\"CommandState\":2,\"CompanyId\":60591,\"OperationalMode\":2,\"Priority\":99,\"ComPortAddress\":3,\"ComportAddrType\":10,\"MACAddress\":\"0080A3E3F71C\",\"FailureReason\":\"\",\"RetryCounter\":0,\"LastUpdate\":\"2021-03-24T14:09:44.857\",\"PickedForProcessing\":1,\"ParentId\":3350,\"IsParentCommand\":false,\"IsChildCommand\":true}]",
            "MessageObjectType": "System.Data.DataTable",
            "AcknowledgeCount": 0,
            "ackOperator": "00000000-0000-0000-0000-000000000000"
        }
    }
    global.showProgress = (title, canAbort, abortOrTimeoutCallback, timeoutMilliSeconds, progressText, canClose, closeCallback, comDevs) => {
        progressLog('showProgress()');
        clearTimeoutMilliSeconds();
        clearTimers();
        executeAbortOrTimeoutCallBack();
        hideProgressText();
        hideAbortButton();
        hideCloseButton();
        clearWebAlertData();
        hideDetailsLink();
        setProgressRequestIdAttr();
        setTitle(title);
        showLoader();
        setProgressIf(progressText);
        if (canClose === false) showClose(); else showClose(); //if (canClose === false) showAbortIf(canAbort); else showClose(); // abort button is removed for beta
        showModal();
        adjustPosition();
        setTimeoutMilliSeconds(timeoutMilliSeconds);
        setAbortOrTimeoutCallback(abortOrTimeoutCallback);
        setCloseCallback(closeCallback);
        setComDevices(comDevs);
    };
    global.updateProgress = (txt, doResetTimer = true) => {
        setProgressText(txt);
        adjustPosition();
        if (doResetTimer) {
            resetTimer();
        }
    };
    global.updateError = (err, wAD) => updateError(err, wAD);
    global.updatePartialError = updatePartialError;
    global.updateSuccess = wAD => updateSuccess(wAD);
    global.updatePartialSuccess = updatePartialSuccess;
    global.hideProgress = hideModal;
    global.getPendingCommandCount = getPendingCommandCount;
    global.decrementPendingCommandCount = decrementPendingCommandCount;
    global.uuidv4 = () => {
        lastProgressRequestID = ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
            (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
        );

        console.log("SignalRClientID : " + globalHub.connection.id); // TODO: DELETE
        console.log("ProgressRequestID : " + lastProgressRequestID); // TODO: DELETE

        return lastProgressRequestID;
    };
    global.setSignalrIdProgressIdToHiddenField = () => {
        $('#hdnGlobalHub').val(globalHub.connection.id);
        $('#hdnProgressId').val(uuidv4());
    };
    global.showBusyDialog = (title, canAbort, abortOrTimeoutCallback, timeoutMilliSeconds, progressText, canClose, closeCallback) => {
        progressLog('showBusyDialog()');
        if (!isProgressOpen()) {
            showProgress(title, canAbort, abortOrTimeoutCallback, timeoutMilliSeconds, progressText, canClose, closeCallback);
            progressLog('showBusyDialog() accepted');
        } else {
            progressLog('showBusyDialog() refused');
        }
    };
    global.hideBusyDialog = () => {
        progressLog('hideBusyDialog()');
        if (!isProgressOpen()) {
            hideModal();
            progressLog('hideBusyDialog() accepted');
        } else {
            progressLog('hideBusyDialog() rejected');
        }
    };
    global.dlgTests = {
        test1,
        test2,
        test3,
        test4,
        test5,
        test6,
        test7,
        test8
    };
    global.isDetailsLinkVisible = () => {
        return $detailsLink.is(':visible') && visibleDetailsLinkOnProgressModal.toLowerCase() == 'true';
    };
    function progressLog(message) {
        //console.log(message);
    }
    function test1() {
        alert('busy dialog will open and close after 5 seconds');
        progressLog(test1);
        showBusyDialog('Busy dialog');
        setTimeout(hideBusyDialog, 5000);
    }
    function test2() {
        alert('busy dialog will not open due to DlgProgress is opened');
        progressLog(test2);
        showProgress('DlgProgress', false, () => alert('timeout callback'), 20 * 1000);
        setTimeout(() => showBusyDialog('Busy dialog'), 1000);
        setTimeout(hideBusyDialog, 5000);
    }
    function test3() {
        alert('busy dialog will open, but DlgProgress will override it');
        progressLog(test3);
        showBusyDialog('Busy dialog');
        setTimeout(() => showProgress('DlgProgress', false, () => alert('timeout callback'), 20 * 1000), 5 * 1000);
        setTimeout(hideBusyDialog, 10 * 1000);
    }
    function test4() {
        alert('timeout call back will execute after 5 seconds');
        progressLog(test4);
        setTimeout(() => showProgress('DlgProgress', false, () => alert('time out callback'), 5 * 1000), 1000);
    }
    function test5() {
        alert('Close callback will execute after clicking Close button');
        progressLog(test5);
        setTimeout(() => showProgress('DlgProgress', false, () => alert('time out callback'), 5 * 1000, 'Dlg progress', true, () => alert('Close callback')), 1000);
    }
    function test6() {
        alert('Text will update');
        progressLog(test5);
        setTimeout(() => showProgress('DlgProgress', false, () => alert('time out callback'), 5 * 1000, 'Dlg progress', true, () => alert('Close callback')), 0);
        setTimeout(() => updateProgress('This is a test progress'), 2000);
    }
    function test7() {
        alert('Error will update');
        progressLog(test5);
        setTimeout(() => showProgress('DlgProgress', false, () => alert('time out callback'), 5 * 1000, 'Dlg progress', true, () => alert('Close callback')), 0);
        setTimeout(() => updateError('This is a test error'), 2000);
    }
    function test8() {
        alert('Success will update and no timeout callback will execute');
        progressLog(test5);
        setTimeout(() => showProgress('DlgProgress', false, () => alert('time out callback'), 5 * 1000, 'Dlg progress', true, () => alert('Close callback')), 0);
        setTimeout(() => updateSuccess('This is a test success'), 2000);
    }
})(window);

const addNotifyDataCallback = (successCallback, errorCallBack) => {
    const removeNotifyDataCallback = () => {
        const index = notifyDataCallbacks.indexOf(notifyDataCallback);
        if (index !== -1) notifyDataCallbacks.splice(index, 1);
    };

    const notifyDataCallback = (webAlertData) => {
        const codedSubMessageID = JSON.parse(webAlertData).DataObject.CodedSubMessageID;
        switch (codedSubMessageID) {
            case CodedSubMessageID.Started:
            case CodedSubMessageID.InProgress:
                break;
            case CodedSubMessageID.Success:
                removeNotifyDataCallback();
                if ($.isFunction(successCallback) && !isDetailsLinkVisible()) successCallback(webAlertData);
                break;
            case CodedSubMessageID.Failed:
            case CodedSubMessageID.NetworkFail:
                removeNotifyDataCallback();
                if ($.isFunction(errorCallBack) && !isDetailsLinkVisible()) errorCallBack();
                break;
            case CodedSubMessageID.None:
            default:
                break;
        }
    };

    if (!notifyDataCallbacks.includes(notifyDataCallback)) notifyDataCallbacks.push(notifyDataCallback);
    return removeNotifyDataCallback;
};

function createLinkTag(logo) {
    var link = document.querySelector("link[rel*='icon']") || document.createElement('link');
    link.type = 'image/x-icon';
    link.rel = 'shortcut icon';
    link.href = '../../Images/' + logo;
    document.getElementsByTagName('head')[0].appendChild(link);
}

function showAlertAsync(title, content) {
    return new Promise(function (resolve, reject) {
        $.confirm({
            title: title,
            content: content,
            buttons: {
                ok: function () {
                    resolve();
                }
            }
        });
    });
}

const showAlert = (title, content) => {
    $.alert({
        title: title,
        content: content
    });
};

const showConfirm = (title, content, callback, cancelCallback) => {
    $.confirm({
        title: title,
        content: content,
        buttons: {
            confirm: {
                text: (typeof yesText !== 'undefined') ? yesText : 'Yes',
                id: 'btnConfirm',
                action: function () {
                    if (callback) {
                        callback();
                    }
                }
            },
            cancel: {
                text: (typeof cancelText !== 'undefined') ? cancelText : 'Cancel',
                action: function () {
                    if (cancelCallback) {
                        cancelCallback();
                    }
                }
            }
        }
    });

    setTimeout(() => $('.jconfirm-buttons button').first().focus(), 1);
};

function showConfirmAsync(title, content) {
    return new Promise(function (resolve, reject) {
        $.confirm({
            title: title,
            content: content,
            buttons: {
                confirm: {
                    text: 'Yes',
                    action: function () {
                        resolve(true);
                    }
                },
                cancel: function () {
                    resolve(false);
                }
            }
        });
    });
}

async function checkSessionAliveAsync() {
    try {
        return JSON.parse(await postAsync(`${baseUrlCAWebService}/CheckSessionAlive`, {}, null, false));
    } catch (e) {
        return false;
    }
}

const getSecurityLevel = (screenName) => {
    let securityLevel = 0;
    $.ajax({
        type: "POST",
        url: baseUrlCAWebService + "/GetSecurityLevel",
        data: "{ ScreenName: '" + screenName + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        async: false,
        success: function (msg) {
            securityLevel = msg.d;
        },
        error: function (data, status, jqXHR) {
        }
    });
    return securityLevel;
};

async function getSecurityLevelAsync(screenName, title, busy = false) {
    const url = `${baseUrlCAWebService}/GetSecurityLevel`;
    const data = {
        ScreenName: screenName
    };
    const securityLevel = await postAsync(url, data, title, busy);
    return securityLevel;
}


const doWriteConfig = (hcsNo, comport, comportaddress, companyId, caObjectId, callback) => {
    stopAjaxStartShowProgress = stopAjaxStopHideProgress = true;
    $.ajax({
        type: "POST",
        url: BASE_URL + "/Configuration/ComPortsHosting/ComportsHostingBrowser.aspx/ConfigurationEditorToolBar1_OnWriteConfig",
        data: JSON.stringify({ hcsNo, comport, comportaddress, companyId, caObjectId, signalRClientID: document.getElementById("hdnGlobalHub").value, progressRequestID: uuidv4() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        async: false,
        success: function (msg) {
            if (callback) {
                callback(msg.d);
            }
        },
        error: function (data, status, jqXHR) {
            updateProgress(data.responseText);
        }
    });
};

function doReadConfig(comport, comportaddress, comportAddrType, companyId, callback) {
    stopAjaxStartShowProgress = stopAjaxStopHideProgress = true;
    $.ajax({
        type: "POST",
        url: BASE_URL + "/Configuration/ComPortsHosting/ComportsHostingBrowser.aspx/ConfigurationEditorToolBar1_OnReadConfig",
        data: JSON.stringify({ comport, comportaddress, comportAddrType, companyId, signalRClientID: document.getElementById("hdnGlobalHub").value, progressRequestID: uuidv4() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        async: true,
        success: function (msg) {
            if (callback) {
                callback(msg.d);
            }
        },
        error: function (data, status, jqXHR) {
            updateProgress(data.responseText);
        }
    });
};

const doDownloadNlmFirmware = (comport, comportaddress, companyId, callback) => {
    stopAjaxStartShowProgress = stopAjaxStopHideProgress = true;
    $.ajax({
        type: "POST",
        url: BASE_URL + "/Configuration/ComPortsHosting/ComportsHostingBrowser.aspx/ConfigurationEditorToolBar1_OnDownloadFirmware",
        data: JSON.stringify({ comport, comportaddress, companyId, signalRClientID: document.getElementById("hdnGlobalHub").value, progressRequestID: uuidv4() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        async: false,
        success: function (msg) {
            if (callback) {
                callback(msg.d);
            }
        },
        error: function (data, status, jqXHR) {
            updateProgress(data.responseText);
            showAlert("Effor", "Error!!!!!!!!!!");
        }
    });
};

//******lock-down-control*******
$(document).on("click", '#lock-down-control', function (event) {
    showProgress(undefined, undefined, undefined, undefined, undefined, undefined);
    lockDownLog = "";
    threatLevelLog = "";
    $('#lockdownAreasThreatLevelApbAreaModalTemplate').html('');
    $('#lockdownAreasThreatLevelApbAreaModalTemplate').load(BASE_URL + "HtmlTemplates/lockdown-areas-threat-level-apb-area-modal.html?t=" + Math.floor(Date.now() / 1000), () => {
        jQuery('#lockdown-areas-threat-level-apb-area-modal').modal('show', { backdrop: 'static' });
        $('#lockdown-areas-threat-level-apb-area-modal').on('shown.bs.modal', function () {
            $('#lockdown-areas-threat-level-apb-area-modal .modal-title').html(string_Lockdown_Control);
            loadLockdownAreas();
            loadThreatLevels();
            GetCommandStatusFromCommun();
            hideProgress();
        });
    });
});

const loadLockdownAreas = (initialLoad = true) => {

    if (initialLoad) {
        $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-lockdown-area .card-header').html(string_LockDownAreas);
        $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-lockdown-area .card-body').html('');
    }
    getLockdownAreaNames(function (data) {
        if (!initialLoad) $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-lockdown-area .card-body').html('');
        const lockdownAreas = JSON.parse(data);
        if (lockdownAreas.length === 0) {
            $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-lockdown-area .card-body').append(`<div class="form-group row">
									<label class="col-md-12 col-form-label font-weight-bold" style="color: orange">${string_NoLockdownAreaConfigured}</label>
								</div>`);
        }
        $.each(lockdownAreas, function (index, lockdownArea) {
            let csbtnClass = commandStatusDangerButtonList.indexOf(`ldcs-btn-${lockdownArea.AreaNo}`) != -1 ? 'text-danger' : '';
            let btnClass = 'btn-success';
            let btnText = string_Activate;
            let groupBtnClass = "btn-group d-none";
            if (lockdownArea.Active) {
                btnClass = 'btn-danger';
                btnText = string_Deactivate;
                groupBtnClass = "btn-group disabled-div d-none";
            }
            let row = `<div class="form-group row mb-1 ldtl-row" id=${lockdownArea.AreaNo} style="padding-right: 32px;">
									<label class="col-md-8 col-form-label font-weight-bold">${lockdownArea.AreaName}</label>
									<div class="col-md-4 p-0">
                                        <div class="btn-group ${lockdownArea.IsTLActive ? 'disabled-div' : ''}" role="group">
                                        <button type="button" class="btn-act-deact btn btn-block ${btnClass}" activate=${lockdownArea.Active} style="width: 130px;">
											${btnText}
										</button>
                                        <div class="${groupBtnClass}" role="group">
                                            <button type="button" id=ldBtnGroup-${lockdownArea.AreaNo} class="btn btn-block dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="box-shadow: none;"></button>
                                            <div class="dropdown-menu ldc-menu p-0 m-0" style='background:none;border:none;width:0;' aria-labelledby=ldBtnGroup-${lockdownArea.AreaNo}>
                                              <button type="button" class="btn-act-deact btn btn-danger" style="margin-left: 37px;">
											    ${string_ForceDeactivate}
										      </button>
                                            </div>
                                         </div>
                                        </div>
                                       <a href="javascript:void(0)" id='ldcs-btn-${lockdownArea.AreaNo}' onclick="onLockdownDetailsClick(${lockdownArea.AreaNo})" class="align-text-top ml-1 ${csbtnClass} ${lockdownArea.IsTLActive ? 'disabled-div' : ''}">
                                            <i style="font-size: 18px;" class="fas fa-info-circle" title="Status"></i>
                                       </a>
									</div>
								</div>`;
            $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-lockdown-area .card-body').append(row);
            isCommandExecutionFailed(0, lockdownArea.AreaNo);
        });
    });
};

const loadThreatLevels = (initialLoad = true) => {
    if (initialLoad) {
        $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-threat-level .card-header').html(string_Threat_Level);
        $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-threat-level .card-body').html('');
    }
    getThreatLevels(function (data) {
        if (!initialLoad) $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-threat-level .card-body').html('');
        const threatLevels = JSON.parse(data);
        if (threatLevels.length === 0) {
            $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-threat-level .card-body').append(`<div class="form-group row">
									<label class="col-md-12 col-form-label font-weight-bold" style="color: orange">${string_NoThreatLevelConfigured}</label>
								</div>`);
        }
        $.each(threatLevels, function (index, threatLevel) {
            let csbtnClass = commandStatusDangerButtonList.indexOf(`tlcs-btn-${threatLevel.LockdownID}`) != -1 ? 'text-danger' : '';
            let btnClass = 'btn-success';
            let btnText = string_Activate;
            let groupBtnClass = "btn-group d-none";
            if (threatLevel.Active) {
                btnClass = 'btn-danger';
                btnText = string_Deactivate;
                groupBtnClass = "btn-group disabled-div d-none";
            }
            let row = `<div class="form-group row mb-1 ldtl-row" id=${threatLevel.LockdownID} style="padding-right: 32px;">
									<label class="col-md-8 col-form-label font-weight-bold">${threatLevel.Description}</label>
									<div class="col-md-4 p-0">
                                    <div class="btn-group" role="group">
                                        <button type="button" class="btn-act-deact btn btn-block ${btnClass}" activate=${threatLevel.Active} style="width: 130px;">
											    ${btnText}
								        </button>
                                        <div class="${groupBtnClass}" role="group">
                                            <button type="button" id=tlBtnGroup-${threatLevel.LockdownID} class="btn btn-block dropdown-toggle"
                                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="box-shadow: none;"></button>
                                            <div class="dropdown-menu ldc-menu p-0" style='background:none;border:none;width:0;' aria-labelledby=tlBtnGroup-${threatLevel.LockdownID}>
                                              <button type="button" class="btn-act-deact btn btn-danger" style="margin-left: 37px;">
											    ${string_ForceDeactivate}
										      </button>
                                            </div>
                                         </div>
                                       </div>
                                      <a href="javascript:void(0)" id='tlcs-btn-${threatLevel.LockdownID}' onclick="onThreatLevelDetailsClick(${threatLevel.LockdownID})" class="align-text-top ml-1 ${csbtnClass}">
                                          <i style="font-size: 18px;" class="fas fa-info-circle" title="Status"></i>
                                      </a>
								    </div>
								</div>`;
            $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-threat-level .card-body').append(row);
            isCommandExecutionFailed(1, threatLevel.LockdownID);
        });
    });
};

const getLockdownAreaNames = (callback) => {
    $.ajax({
        type: "POST",
        url: baseUrlCAWebService + '/GetLockdownAreaNames',
        data: "{companyId: " + companyId + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        async: false,
        success: function (msg) {
            if (callback) {
                callback(msg.d);
            }
        },
        error: function (data, status, jqXHR) {
            //updateProgress(data.responseText);
            showAlert("Error", data.responseText);
        }
    });
};

const getActiveLockdownArea = (callback) => {
    $.ajax({
        type: "POST",
        url: baseUrlCAWebService + '/GetActiveLockdownArea',
        data: "{companyId: " + companyId + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (msg) {
            if (callback) {
                callback(msg.d);
            }
        },
        error: function (data, status, jqXHR) {
            showAlert("Error", data.responseText);
        }
    });
};

const getThreatLevels = (callback) => {
    $.ajax({
        type: "POST",
        url: baseUrlCAWebService + '/GetThreatLevels',
        data: "{companyId: " + companyId + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        async: false,
        success: function (msg) {
            if (callback) {
                callback(msg.d);
            }
        },
        error: function (data, status, jqXHR) {
            //updateProgress(data.responseText);
            showAlert("Error", data.responseText);
        }
    });
};

const getActiveThreatLevel = (callback) => {
    $.ajax({
        type: "POST",
        url: baseUrlCAWebService + '/GetActiveThreatLevel',
        data: "{companyId: " + companyId + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (msg) {
            if (callback) {
                callback(msg.d);
            }
        },
        error: function (data, status, jqXHR) {
            //updateProgress(data.responseText);
            showAlert("Error", data.responseText);
        }
    });
};

$(document).on('click', '.card-threat-level .btn-act-deact', function (e) {
    let activate = $(e.target).attr('activate');
    let threatLevelArea, threatLevelName;
    if (activate) {
        threatLevelArea = $(e.target.parentElement.parentElement.parentElement).attr('id');
        threatLevelName = $(e.target.parentElement.parentElement).siblings('label').html();
    }
    else {
        activate = 'true';
        threatLevelArea = $(e.target.parentElement.parentElement.parentElement.parentElement.parentElement).attr('id');
        threatLevelName = $(e.target.parentElement.parentElement.parentElement.parentElement).siblings('label').html();
    }
    let msgContent = string_ThreatActivatePrompt;
    let activateVal = true;
    if (activate === 'true') {
        msgContent = string_ThreatDeactivatePrompt;
        activateVal = false;
    }
    msgContent = msgContent + ' ' + threatLevelName;
    showConfirm(string_Confirmation, msgContent, function () {
        stopAjaxStartShowProgress = stopAjaxStopHideProgress = true;
        showProgress(string_Threat_Level, undefined, undefined, timeoutMillisecondsDefault, undefined, undefined);
        doRequestThreatLevelCallback(threatLevelArea, activateVal, function (data) {
            addNotifyDataCallback(function () {
                loadLockdownAreas(false);
                updateButtonStatus(e);
                applyLockdownThreatlevelMarquee();
            }, null);
        }, null, function () {
            hideProgress();
            $('#title').text(string_Threat_Level);
            $(".progress-modal-content #title").attr("output", `${CodedSubMessageID.TLOutput}`);

            commandStatusProgressRequestIdList = commandStatusProgressRequestIdList.filter(x => x.id != `tlcs-btn-${threatLevelArea}`);
            commandStatusProgressRequestIdList.push({ id: `tlcs-btn-${threatLevelArea}`, value: lastProgressRequestID });
            $(`#tlcs-btn-${threatLevelArea}`).removeAttr('progress-request-id').attr('progress-request-id', lastProgressRequestID);
            onThreatLevelDetailsClick(threatLevelArea, true);
        }, e);
    });
});

const updateButtonStatus = (e) => {
    $(e.target).attr('activate', 'true');
    if ($(e.target).hasClass('btn-success')) {
        $(e.target).html(string_Deactivate).removeClass('btn-success').addClass('btn-danger').attr('activate', 'true');
    }
    else {
        $(e.target).html(string_Activate).removeClass('btn-danger').addClass('btn-success').attr('activate', 'false');
    }
};

$(document).on('click', '.card-lockdown-area .btn-act-deact', function (e) {
    let activate = $(e.target).attr('activate');
    let areaNo;
    if (activate) {
        areaNo = $(e.target.parentElement.parentElement.parentElement).attr('id');
    }
    else {
        activate = 'true';
        areaNo = $(e.target.parentElement.parentElement.parentElement.parentElement.parentElement).attr('id');
    }
    let msgContent = string_LockdownActivatePrompt;
    let activateVal = true;
    let actByOpr = true;
    if (activate === 'true') {
        msgContent = string_LockdownDeactivatePrompt;
        activateVal = false;
        actByOpr = false;
    }
    showConfirm(string_Confirmation, msgContent, function () {
        stopAjaxStartShowProgress = stopAjaxStopHideProgress = true;
        showProgress(string_LockDownAreas, undefined, undefined, timeoutMillisecondsDefault, undefined, undefined);
        doRequestLockDownCallback(activateVal, areaNo, actByOpr, function (data) {
            addNotifyDataCallback(function () {
                updateButtonStatus(e);
                applyLockdownThreatlevelMarquee();
            }, null);
        }, null, function () {
            hideProgress();
            $('#title').text(string_LockDownAreas);
            $(".progress-modal-content #title").attr("output", `${CodedSubMessageID.LDOutput}`);

            commandStatusProgressRequestIdList = commandStatusProgressRequestIdList.filter(x => x.id != `ldcs-btn-${areaNo}`);
            commandStatusProgressRequestIdList.push({ id: `ldcs-btn-${areaNo}`, value: lastProgressRequestID });
            $(`#ldcs-btn-${areaNo}`).removeAttr('progress-request-id').attr('progress-request-id', lastProgressRequestID);
            onLockdownDetailsClick(areaNo, true);
        }, e);
    });
});

function doRequestLockDown(activate, areaNo, actByOpr, callback) {
    //console.log("doRequestLockDown()");
    $.ajax({
        type: "POST",
        url: BASE_URL + "View/Service/StatusWebService.asmx/DoRequestLockDown",
        data: "{ pIsLockDown: " + activate + ", pArea: " + areaNo + ", actByOpr: " + actByOpr + ", companyId:" + companyId + " }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (msg) {
            if (callback) {
                callback(msg.d);
            }
        },
        failure: function (msg) {
            console.log("Failure: doRequestLockDown");
        }
    });
}

function doRequestLockDownCallback(activate, areaNo, actByOpr, callback, childMetadata, statusCallback, elementRef = null) {
    //console.log("doRequestLockDownCallback()");
    const _signalRClientID = globalHub.connection.id;
    let childMetadataStr = '';
    if (childMetadata)
        childMetadataStr = JSON.stringify(childMetadata);
    $.ajax({
        type: "POST",
        url: BASE_URL + "View/Service/StatusWebService.asmx/DoRequestLockDownCallback",
        data: "{ pIsLockDown: " + activate + ", pArea: " + areaNo + ", actByOpr: " + actByOpr + ", companyId:" + companyId + ", signalRClientID: '" + _signalRClientID + "', progressRequestID: '" + uuidv4() + "', childMetadataStr: '" + childMetadataStr + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (msg) {
            if (msg.d) {
                $("#progress-modal-parent-command-id-element").text('');
                if ($.isNumeric(msg.d)) {
                    $("#progress-modal-parent-command-id-element").append(msg.d);
                }
                if (callback)
                    callback(msg.d);
                if (statusCallback)
                    statusCallback();
            }
            else if (!msg.d && !activate) {
                doRequestLockDown(activate, areaNo, actByOpr, function () {
                    if (elementRef)
                        updateButtonStatus(elementRef);
                    applyLockdownThreatlevelMarquee();
                    hideProgress();
                });
            }
            else {
                hideProgress();
                alert("No reader assigned in this lockdown area.");
            }
        },
        failure: function (msg) {
            hideProgress();
            console.log("Failure: doRequestLockDownCallback");
        }
    });
}

function doRequestThreatLevel(areaNo, pActive, callback) {
    //    console.log("doRequestThreatLevel()");
    $.ajax({
        type: "POST",
        url: BASE_URL + "View/Service/StatusWebService.asmx/DoRequestThreatLevel",
        data: "{ pArea: " + areaNo + ", pActive: " + pActive + ", companyId:" + companyId + " }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        async: false,
        success: function (msg) {
            if (callback)
                callback(msg.d);
        },
        failure: function (msg) {
            console.log("Failure: doRequestThreatLevel");
        }
    });
}

function doRequestThreatLevelCallback(areaNo, pActive, callback, childMetadata, statusCallback, elementRef = null) {
    //    console.log("doRequestThreatLevelCallback()");
    const _signalRClientID = globalHub.connection.id;
    let childMetadataStr = '';
    if (childMetadata)
        childMetadataStr = JSON.stringify(childMetadata);
    $.ajax({
        type: "POST",
        url: BASE_URL + "View/Service/StatusWebService.asmx/DoRequestThreatLevelCallBack",
        data: "{ pArea: " + areaNo + ", pActive: " + pActive + ", companyId:" + companyId + ", signalRClientID:'" + _signalRClientID + "', progressRequestID: '" + uuidv4() + "', childMetadataStr: '" + childMetadataStr + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        async: false,
        success: function (msg) {
            if (msg.d) {
                $("#progress-modal-parent-command-id-element").text('');
                if ($.isNumeric(msg.d)) {
                    $("#progress-modal-parent-command-id-element").append(msg.d);
                }
                if (callback)
                    callback(msg.d);
                if (statusCallback)
                    statusCallback();
            }
            else if (!msg.d && !pActive) {
                doRequestThreatLevel(areaNo, pActive, function () {
                    loadLockdownAreas(false);
                    if (elementRef)
                        updateButtonStatus(elementRef);
                    applyLockdownThreatlevelMarquee();
                    hideProgress();
                });
            }
            else {
                hideProgress();
                alert("No reader assigned in the selected lockdown area.");
            }
        },
        failure: function (msg) {
            hideProgress();
            console.log("Failure: doRequestThreatLevelCallback");
        }
    });
}

const getLockdownPromise = () => {
    return new Promise((resolve, reject) => {
        getActiveLockdownArea(function (data) {
            if (data) {
                const jsonData = JSON.parse(data);
                const lockdowns = jsonData.map((item) => {
                    return `[${item.AreaName}]`;
                }).join(" ");
                resolve({ "Key": "LOCK_DOWNS", "Value": lockdowns });
            }
            else {
                resolve({ "Key": "LOCK_DOWNS", "Value": "" });
            }
        });
    });
};

const getThreatLevelPromise = () => {
    return new Promise((resolve, reject) => {
        getActiveThreatLevel(function (data) {
            if (data) {
                const jsonData = JSON.parse(data);
                const threatLevels = jsonData.map((item) => {
                    return `[${item.Text}]`;
                }).join(" ");
                resolve({ "Key": "THREAT_LEVELS", "Value": threatLevels });
            }
            else {
                resolve({ "Key": "THREAT_LEVELS", "Value": "" });
            }
        });
    });
};

var lockdownMarqueeString;
var threatlevelMarqueeString;
function applyLockdownThreatlevelMarquee(autoUpdate = false) {
    //$(".lockdown-threatlevel-container").empty();
    const lockdown = getLockdownPromise();
    const threat = getThreatLevelPromise();
    Promise.all([lockdown, threat]).then((values) => {
        let leftPos = 4;
        const lockdowns = values.find((item) => item.Key === 'LOCK_DOWNS');
        if (!autoUpdate || lockdowns.Value != lockdownMarqueeString) {
            lockdownMarqueeString = lockdowns.Value;
            if (lockdowns && lockdowns.Value.length > 0) {
                let $div = $("<div>", { "id": "lockdown-marquee", "class": "lockdown-status marquee me-5", "style": `left:${leftPos}px;` });
                $("#lockdown-marquee").remove();
                $(".lockdown-threatlevel-container").prepend($div);
                $('.lockdown-status').show().html(`${string_Report_Lockdown}- ${lockdowns.Value}`);
                $('.lockdown-status').marquee({
                    speed: 5000,
                    gap: 50,
                    delayBeforeStart: 0,
                    direction: 'left',
                    duplicated: true,
                    pauseOnHover: true
                });
            }
            else {
                $("#lockdown-marquee").remove();
            }
        }
        leftPos = leftPos + 316;
        const threatlevels = values.find((item) => item.Key === 'THREAT_LEVELS');
        if (!autoUpdate || threatlevels.Value != threatlevelMarqueeString) {
            threatlevelMarqueeString = threatlevels.Value;
            if (threatlevels && threatlevels.Value.length > 0) {
                let $div = $("<div>", { "id": "threatlevel-marquee", "class": "threatlevel-status marquee", "style": `left:${leftPos}px;` });
                $("#threatlevel-marquee").remove();
                $(".lockdown-threatlevel-container").append($div);
                $('.threatlevel-status').show().html(`${string_Threat_Level}- ${threatlevels.Value}`);
                $('.threatlevel-status').marquee({
                    speed: 5000,
                    gap: 50,
                    delayBeforeStart: 0,
                    direction: 'left',
                    duplicated: true,
                    pauseOnHover: true
                });
            }
            else {
                $("#threatlevel-marquee").remove();
            }
        }
    });
}

function getFailedPanelCommandStateCount(companyId, panelNo, commandStates) {
    $.ajax({
        type: "POST",
        url: baseUrlCAWebService + '/GetFailedPanelCommandStateCount',
        data: "{companyId:" + companyId + ",panelNo:" + panelNo + ",commandStates:'" + commandStates + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (msg) {
            var data = JSON.parse(msg.d);
            if (parseInt(data) > 0) {
                $('#dropdown-warning-control').removeClass("d-none");
            }
            else {
                $('#dropdown-warning-control').addClass("d-none");
            }
        },
        failure: function (msg) {
            console.log("Failure: getFailedPanelCommandStateCount() > GetFailedPanelCommandStateCount");
        }
    });
}

function loadFailedPanelCommandState(companyId, panelNo, commandStates) {
    $("#failedPanelCommandState").attr("companyId", companyId).attr("panelNo", panelNo).attr("commandStates", commandStates);
    $.ajax({
        type: "POST",
        url: baseUrlCAWebService + '/GetPanelCommandState',
        data: "{companyId:" + companyId + ",panelNo:" + panelNo + ",commandStates:'" + commandStates + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (msg) {
            $('#failedPanelCommandState').html('');
            var cummons = JSON.parse(msg.d);
            if (selectedPanelIndex == -2 && cummons.length == 1) selectedPanelIndex = 0;
            let showDownloadMsg = false;
            $.each(cummons, function (index, item) {
                if (item.BoolItem1 && item.IntItem1 != 0) showDownloadMsg = true;
                var row = `<div class="card">`;
                row = row + `<div class="card-header fa fa-plus" id="card-header-${item.CompanyId}-${item.IntItem1}" data-toggle="collapse"
                             data-target="#collapse-${item.CompanyId}-${item.IntItem1}" aria-expanded="true" aria-controls="collapse-${item.CompanyId}-${item.IntItem1}" style="cursor:pointer;">&nbsp;&nbsp;${item.IntItem1 != 0 ? item.StringItem1 : `${item.InnerFrameClass[0].CompanyName} Radio/Gateway Command`}</div>
                             ${item.BoolItem1 && item.IntItem1 != 0 ? `<button id="download-${item.CompanyId}-${item.IntItem1}" class="btn d-btn-success" style="top:7px;right:32px;position: absolute;font-size:7pt;letter-spacing:2px;text-transform:uppercase;" onclick="panelRequireFullDownload(${item.CompanyId},${item.IntItem1},'${item.StringItem1}',${panelNo == 0})">${string_Download}</button>` : ''}`;
                row = row + `<div id="collapse-${item.CompanyId}-${item.IntItem1}" class="collapse ${index == selectedPanelIndex ? 'show' : ''}" aria-labelledby="card-header-${item.CompanyId}-${item.IntItem1}" index="${index}" data-parent="#failedPanelCommandState">`;
                row = row + `<div class="card-body ml-3">`;
                row = row + `<table id="table-${item.CompanyId}-${item.IntItem1}" class="table table-hover table-striped table-bordered fixed-header">
                           <thead>
                                <tr>
                                    <th style="min-width: 200px; max-width: 200px; width: 200px;"></th>
                                    <th style="min-width: 60px; max-width: 60px; width: 60px;"></th>
                                    <th style="min-width: 120px; max-width: 120px; width: 120px;"></th>
                                    <th style="min-width: 150px; max-width: 150px; width: 150px;"></th>
                                    <th style="min-width: 100px; max-width: 100px; width: 100px;"></th>
                                    <th style="min-width: 100px; max-width: 100px; width: 100px;"></th>
                                    <th style="min-width: 200px; max-width: 200px; width: 200px;"></th>
                                </tr>
                           </thead>
                           <tbody style="overflow:hidden;">`;
                $.each(item.InnerFrameClass, function (index, cummon) {
                    row = row + '<tr>';
                    row = row + '<td style="min-width: 200px; max-width: 200px; width: 200px;">' + cummon.StringItem1 + '</td><td style="min-width: 60px; max-width: 60px; width: 60px;">' + cummon.StringItem2 + '</td><td style="min-width: 120px; max-width: 120px; width: 120px;">' + cummon.StringItem3 + '</td>';
                    row = row + '<td style="min-width: 150px; max-width: 150px; width: 150px;">' + cummon.DateItem1 + '</td><td style="min-width: 100px; max-width: 100px; width: 100px;">' + cummon.StringItem4 + '</td>';
                    row = row + '<td style="min-width: 100px; max-width: 100px; width: 100px;">' + cummon.StringItem5 + '</td><td style="min-width: 200px; max-width: 200px; width: 200px;">' + cummon.CompanyName + '</td>';
                    row = row + '</tr>';
                });
                row = row + '</tbody>';
                row = row + '</table>';
                row = row + '</div></div></div>';
                $('#failedPanelCommandState').append(row);
            });
            if (cummons.length > 0) {
                var companyIdAttr = $("#failedPanelCommandState").attr('companyId');
                var panelNoAttr = $("#failedPanelCommandState").attr('panelNo');
                var commandStatesAttr = $("#failedPanelCommandState").attr('commandStates');
                if ((typeof companyIdAttr !== 'undefined' && companyIdAttr !== false)
                    && (typeof panelNoAttr !== 'undefined' && panelNoAttr !== false)
                    && (typeof commandStatesAttr !== 'undefined' && commandStatesAttr !== false)) {

                    setFailedPanelCommandStateTableHeader();
                    if (showDownloadMsg)
                        $("#m-txtRequireFullDownload").removeClass('hidden');
                    else
                        $("#m-txtRequireFullDownload").addClass('hidden');
                    jQuery('#m-communListModal').modal('show', { backdrop: 'static' });
                }
            }
            else {
                $("#failedPanelCommandState").removeAttr("companyId").removeAttr("panelNo").removeAttr("commandStates");
                $('#m-communListModal').modal('hide');
            }
        },
        failure: function (msg) {
            console.log("Failure: loadFailedPanelCommandState() > GetPanelCommandState");
        }
    });
}

$(document).on('click', '.threatlevel-status, .lockdown-status', function (e) {
    $('#lock-down-control').trigger('click');
});

const writeLockdownOutput = (msg) => {
    let ldOutput = $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-lockdown-area-output .card-body');
    let brVal = ldOutput.html().trim().length > 0 ? '<br/>' : '';
    ldOutput.append(`${brVal}<span>${msg}</span>`);
};

const writeThreatLevelOutput = (msg) => {
    let tlOutput = $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-threat-level-output .card-body');
    let brVal = tlOutput.html().trim().length > 0 ? '<br/>' : '';
    tlOutput.append(`${brVal}<span>${msg}</span>`);
};

$(document).on('click', "#ldShowDetails", function () {
    $("#ldcLogModalTitle").text("Lockdown Areas Output Details");
    $("#ldcLogModalBody").html(lockDownLog);
    jQuery('#ldcLog').modal('show', { backdrop: 'static' });
});

$(document).on('click', "#ldClear", function () {
    lockDownLog = "";
    $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-lockdown-area-output .card-body').text('');
});

$(document).on('click', "#tlShowDetails", function () {
    $("#ldcLogModalTitle").text("Threat Level Output Details");
    $("#ldcLogModalBody").html(threatLevelLog);
    jQuery('#ldcLog').modal('show', { backdrop: 'static' });
});

$(document).on('click', "#tlClear", function () {
    threatLevelLog = "";
    $('#lockdown-areas-threat-level-apb-area-modal .modal-body .card-threat-level-output .card-body').text('');
});

$(document).on('click', "#ldcLogModalClose", function () {
    jQuery('#ldcLog').modal('hide');
});

//*************

async function getCommandStatusByProgressModalID(progressModalId) {
    try {
        const resp = JSON.parse(await postAsync(`${baseUrlCAWebService}/GetCommandStatusByProgressModalID`, { progressModalId }));
        console.log(resp);
    }
    catch (e) {
        alert(e);
    }
}

async function postAsync(url, data, title, busy = true) {
    try {
        return (await $.post({
            url,
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            //beforeSend: () => busy ? showBusyDialog(title) : 0,
            //complete: () => busy ? hideBusyDialog() : 0
        })).d;
    } catch (e) {
        throw ((e.responseJSON && e.responseJSON.Message) || e.statusText || e.message);
    }
}

async function sleep(millisecondsToWait) {
    return new Promise(resolve => setTimeout(resolve, millisecondsToWait));
}

async function applyControlsPrivAfterAsync(screenName, parentID) {
    try {
        const scrObjsWithSecLvl = JSON.parse(await postAsync(`${baseUrlCAWebService}/GetSecurityLevelByScreen`, {
            secreenName: screenName
        }, '', false));
        let elmsWithObjLabel = parentID ? $(`#${parentID}`).find('[objectLabel]') : $('[objectLabel]');
        $.each(elmsWithObjLabel, function (index, elm) {
            let objLbl = $(elm).attr('objectLabel');
            let scrObj = scrObjsWithSecLvl.find(x => x.ObjectLabel == objLbl);
            if (scrObj) {
                let secLev = scrObj.SecurityLevel;
                if (secLev == 9) { // Menu Hide
                    $(elm).hide();
                }
                else if (secLev == 8) { //Menu Disabled
                    $(elm).addClass("disabled-control");
                }

                if (secLev == 2) { //Hide
                    $(elm).hide();
                }
                else if (secLev == 1) { //Disabled
                    $(elm).addClass("disabled-control");
                }
            }
        });
    } catch (e) {
        alert(e);
    }
}

async function applyIsAssignedPluginAfterAsync(parentID) {
    try {
        const authorizedPlugins = JSON.parse(await postAsync(`${baseUrlCAWebService}/GetAutorizedPlugin`, {

        }, '', false));
        let elmsWithMenuItem = parentID ? $(`#${parentID}`).find('[menuItem]') : $('[menuItem]');
        $.each(elmsWithMenuItem, function (index, elm) {
            let menuItem = $(elm).attr('menuItem');
            let plugin = authorizedPlugins.find(x => x.includes(menuItem));
            if (!plugin) {
                $(elm).remove();
            }
        });
    } catch (e) {
        alert(e);
    }
}

function doMasterDownloadPanel(companyId, panelNo, pnlName) {
    var M_DOWNLOAD_OPTIONS = [];
    M_DOWNLOAD_OPTIONS.push(15);

    let obj = {
        operatorLoginName,
        aPBAreaNumber: 0,
        resetAPB: false, // APB is not supported in AirAccess
        downloadOptions: M_DOWNLOAD_OPTIONS,
        pnlNo: panelNo,
        pnlName: pnlName,
        companyId: companyId,
        signalRClientID: document.getElementById("hdnGlobalHub").value,
        progressRequestID: uuidv4()
    };

    $.ajax({
        type: "POST",
        url: baseUrlCAWebService + "/DoDownloadPanel",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        async: true,
        beforeSend: function (xhr) {
            showProgress(_downloadPanel, true, undefined, M_DOWNLOAD_OPTIONS.includes("1") ? 3 * 60 * 1000 : timeoutMillisecondsDefault, undefined, M_DOWNLOAD_OPTIONS.includes("1") ? false : undefined);
        },
        success: function (msg) {
            var result = JSON.parse(msg.d);
            if (result === null || result.length === 0) {
                //
            }
            else {
                showAlert(information, result);
            }
            loadFailedPanelCommandState($("#failedPanelCommandState").attr("companyId"),
                $("#failedPanelCommandState").attr("panelNo"), $("#failedPanelCommandState").attr("commandStates"));
        },
        complete: function () {
        },
        error: function (data, status, jqXHR) {
            hideProgress();
            console.log(data);
        }
    });
}

function dateToTicks(date) {
    const epochOffset = 621355968000000000;
    const ticksPerMillisecond = 10000;

    const ticks = date.getTime() * ticksPerMillisecond + epochOffset;

    return ticks;
}

//console.log("__ticks:" + dateToTicks(new Date()));
//console.log("__ticks:" + dateToTicks(new Date('2022-01-20')));