<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VisitorManagement._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="accordion" id="envoy-api-accordion">
        <div class="accordion-item">
            <h2 class="accordion-header" id="core-apis-header">
                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                    Core Apis
                </button>
            </h2>
            <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="core-apis-header" data-bs-parent="#envoy-api-accordion">
                <div class="accordion-body">
                    <div class="card">
                        <h5 class="card-header">Authentication</h5>
                        <div class="card-body">
                            <h5 class="card-title">Get an access token</h5>
                            <p class="card-text">
                                You'll need to exchange the client id, secret, and username and password to get an access token that can be used to make an API request.
                            </p>
                            <a href="#" class="btn btn-primary">Get Token</a>
                        </div>
                    </div>
                    <div class="card">
                        <h5 class="card-header">Companies</h5>
                        <div class="card-body">
                            <h5 class="card-title">Get a company</h5>
                            <p class="card-text">Retrieve details about an organization or account.</p>
                            <a href="#" class="btn btn-primary">Companies</a>
                        </div>
                    </div>
                    <div class="card">
                        <h5 class="card-header">Locations</h5>
                        <div class="card-body">
                            <h5 class="card-title">Get locations</h5>
                            <p class="card-text">Retrieve locations.</p>
                            <a href="#" class="btn btn-primary">Locations</a>
                            <a href="#" class="btn btn-primary">LocationById</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="accordion-item">
            <h2 class="accordion-header" id="visitor-and-protect-api-header">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                    Visitor and Protect Apis
                </button>
            </h2>
            <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="visitor-and-protect-api-header" data-bs-parent="#envoy-api-accordion">
                <div class="accordion-body">
                    <div class="card">
                        <h5 class="card-header">Employees</h5>
                        <div class="card-body">
                            <h5 class="card-title">Special title treatment</h5>
                            <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
                    <div class="card">
                        <h5 class="card-header">Flows</h5>
                        <div class="card-body">
                            <h5 class="card-title">Special title treatment</h5>
                            <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
                    <div class="card">
                        <h5 class="card-header">Entries</h5>
                        <div class="card-body">
                            <h5 class="card-title">Special title treatment</h5>
                            <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
                    <div class="card">
                        <h5 class="card-header">Invites</h5>
                        <div class="card-body">
                            <h5 class="card-title">Special title treatment</h5>
                            <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
                    <div class="card">
                        <h5 class="card-header">Recurring Invites</h5>
                        <div class="card-body">
                            <h5 class="card-title">Special title treatment</h5>
                            <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
                    <div class="card">
                        <h5 class="card-header">Work Schdules</h5>
                        <div class="card-body">
                            <h5 class="card-title">Special title treatment</h5>
                            <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="accordion-item">
            <h2 class="accordion-header" id="spaces-api-header">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                    Spaces Apis
                </button>
            </h2>
            <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="spaces-api-header" data-bs-parent="#envoy-api-accordion">
                <div class="accordion-body">
                    Body
                </div>
            </div>
        </div>
    </div>
</asp:Content>
