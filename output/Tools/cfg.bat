netsh advfirewall firewall delete rule name="CA30 TCP in ports"
netsh advfirewall firewall delete rule name="CA30 TCP out ports"
netsh advfirewall firewall delete rule name="CA30 UDP out ports"
netsh advfirewall firewall delete rule name="CA30 UDP in ports"

netsh advfirewall firewall delete rule name="CA4K TCP in ports"
netsh advfirewall firewall delete rule name="CA4K TCP out ports"
netsh advfirewall firewall delete rule name="CA4K UDP out ports"
netsh advfirewall firewall delete rule name="CA4K UDP in ports"
netsh advfirewall firewall delete rule name="CA4KShell out"
netsh advfirewall firewall delete rule name="CA4KShell in"
netsh advfirewall firewall delete rule name="CA4K Event Action Processor out"
netsh advfirewall firewall delete rule name="CA4K Event Action Processor in"


netsh advfirewall firewall add rule name="CA4K TCP in ports" dir=in action=allow protocol=TCP localport=1433,1434,5001,5003,5501-5505,8003,9000,9001,9002,9003,10050,10081,5601-5605,8888 
netsh advfirewall firewall add rule name="CA4K TCP out ports" dir=out action=allow protocol=TCP remoteport=3001,5001,5003,5501-5505,8003,9000,9001,9002,9003,10001,10081,5601-5605,8888  

netsh advfirewall firewall add rule name="CA4K UDP out ports" dir=out action=allow protocol=UDP localport=1434,30717,30718,48307,47307,45308 
netsh advfirewall firewall add rule name="CA4K UDP in ports" dir=in action=allow protocol=UDP localport=1434,30717,30718,48307,47307,45308

netsh advfirewall firewall add rule name="CA4KShell out" dir=out action=allow protocol=Any program="%ProgramFiles% (x86)\CardAccess4K\CardAccess4K.exe" enable=yes
netsh advfirewall firewall add rule name="CA4KShell in" dir=in action=allow protocol=Any program="%ProgramFiles% (x86)\CardAccess4K\CardAccess4K.exe" enable=yes

netsh advfirewall firewall add rule name="CA4K Event Action Processor out" dir=out action=allow protocol=Any program="%ProgramFiles% (x86)\CardAccess4K\CardAccess.EventActionProcessor.exe" enable=yes
netsh advfirewall firewall add rule name="CA4K Event Action Processor in" dir=in action=allow protocol=Any program="%ProgramFiles% (x86)\CardAccess4K\CardAccess.EventActionProcessor.exe" enable=yes






