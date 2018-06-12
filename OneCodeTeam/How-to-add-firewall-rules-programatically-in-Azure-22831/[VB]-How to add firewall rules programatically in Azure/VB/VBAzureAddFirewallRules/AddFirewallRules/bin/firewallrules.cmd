netsh advfirewall firewall add rule name="ICMPv6" dir=in action=allow enable=yes protocol=icmpv6
netsh advfirewall firewall add rule name="Windows Remote Management (HTTP-In)" dir=in action=allow service=any enable=yes profile=any localport=5985 protocol=tcp
netsh advfirewall firewall add rule name="Allowing Interal Service Traffic"  dir=in action=allow localport=444 protocol=tcp