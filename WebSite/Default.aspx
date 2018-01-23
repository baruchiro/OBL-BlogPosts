<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Async="true" Inherits="_Default" %>

<%@ Register Src="~/UserNameControl.ascx" TagPrefix="uc1" TagName="UserNameControl" %>
<%@ Register Src="~/UserDetailsControl.ascx" TagPrefix="uc1" TagName="UserDetailsControl" %>
<%@ Register Src="~/PostControl.ascx" TagPrefix="uc1" TagName="PostControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- metadata for google search etc'-->
    <meta name="description"
        content="A ASP.NET WebSite for examining candidates for OBL" />
    <meta name="author" content="Baruch rothkoff" />

    <!-- metadata for preview in whatsapp, facebook etc' -->
    <meta property="og:title" content="OBL test" />
    <meta property="og:image" content="http://obl.me/img/logo.png" />
    <meta property="og:description" content="A ASP.NET WebSite for examining candidates for OBL" />

    <title>OBL test</title>
    <link rel="shortcut icon" href="http://obl.me/img/favicon.ico" />
    <link rel="stylesheet" href="App_Themes/StyleSheet.css" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</head>
<body>
    <script>
        //list of all functions that show map per user
        var allFunctions = [];
        function initMap() {
            $(allFunctions).each(function () {
                this();
            });
        }

        //event when updatepanel finish update
        function pageLoad() { initMap() }
    </script>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <div class="header"></div>
        <div class="content">
            <asp:UpdatePanel ID="UpdatePanelRepeater" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- Refresh lists every 5 minutes -->
                    <asp:Timer ID="UpdateTimer" runat="server" Interval="300000" OnTick="UpdateTimer_Tick">
                    </asp:Timer>
                    <asp:Repeater ID="RepeaterPosts" runat="server">
                        <ItemTemplate>
                            <uc1:PostControl runat="server" ID="PostControl" post='<%# GetDataItem() %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="RepeaterJS" runat="server">
                        <ItemTemplate>
                            <script>
                                //alert("SCRIPT");
                                var maps;
                                //each function per user
                                function <%# "initMap"+Eval("id")%>() {
                                    //move on all maps with current user class
                                    $('<%# ".user"+Eval("id")%>').each(function () {
                                        var latlng = { lat: parseInt($(this).data('lat'), 10), lng: parseInt($(this).data('lat'), 10) };
                                        map = new google.maps.Map(this, {
                                            center: latlng,
                                            zoom: 8
                                        });
                                        var marker = new google.maps.Marker({
                                            position: latlng,
                                            map: map
                                        });
                                    });
                                }

                                //add current function to function list
                                allFunctions.push(<%# "initMap"+Eval("id")%>);
                            </script>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- load Maps API and call InitMaps() -->
        <script async="async" defer="defer" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDSnZIRjwChGCPWDBGMMPrAU7e_wubbf6Q&callback=initMap"></script>

    </form>

</body>
</html>
