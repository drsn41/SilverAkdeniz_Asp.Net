<%@ Page Title="" Language="C#" MasterPageFile="~/Other.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" EnableEventValidation="false" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src='https://www.google.com/recaptcha/api.js'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <ul class="breadcrumb">
        <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
        <li class="active">İletişim</li>
    </ul>
    <div class="well well-small">
        <h1>Bizi Ziyaret Edin</h1>
        <hr class="soften" />
        <div class="row-fluid">
            <div class="span8 relative">
                <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&key=6LcowVsUAAAAAKnA2i1-6l9rpExRN88d0_Fi4ajt"></script>
                <script type="text/javascript">
                    var markers = [
                    <asp:Repeater ID="rptMarkers" runat="server">
                    <ItemTemplate>
                             {
                                 "title": '<%# Eval("SiteName") %>',
                     "lat": '<%# Eval("enlem") %>',
                     "lng": '<%# Eval("boylam") %>',
                     "description": '<%# Eval("SiteAddress") %>'
                 }
    </ItemTemplate>
    <SeparatorTemplate>
        ,
    </SeparatorTemplate>
    </asp:Repeater>
        ];
                </script>
                <script type="text/javascript">

                    window.onload = function () {
                        var mapOptions = {
                            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                            zoom: 8,
                            mapTypeId: google.maps.MapTypeId.ROADMAP
                        };
                        var infoWindow = new google.maps.InfoWindow();
                        var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
                        for (i = 0; i < markers.length; i++) {
                            var data = markers[i]
                            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                            var marker = new google.maps.Marker({
                                position: myLatlng,
                                map: map,
                                title: data.title
                            });
                            (function (marker, data) {
                                google.maps.event.addListener(marker, "click", function (e) {
                                    infoWindow.setContent(data.description);
                                    infoWindow.open(map, marker);
                                });
                            })(marker, data);
                        }
                    }
                </script>
                <div id="dvMap" style="width: 100%; height: 350px">
                </div>
                <div class="absoluteBlk">
                    <div class="well wellsmall">
                        <h4>İletişim Detayları</h4>
                        <h5>
                            <asp:Label ID="lblAddress" runat="server"></asp:Label><br />
                            <br />
                            <br />

                            <asp:Label ID="lblEmail" runat="server"></asp:Label><br />
                            <asp:Label ID="lblPhone" runat="server"></asp:Label><br />
                            <br />

                        </h5>
                    </div>
                </div>
            </div>

            <div class="span4">
                <h4>Mesaj Gönder</h4>
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">

                            <asp:TextBox ID="txtName" placeholder="Ad" runat="server" CssClass="input-xlarge"></asp:TextBox>

                        </div>
                        <div class="control-group">

                            <asp:TextBox ID="txtSurname" placeholder="Soyad" runat="server" CssClass="input-xlarge"></asp:TextBox>

                        </div>
                        <div class="control-group">

                            <asp:TextBox ID="txtEmail" placeholder="E-posta" runat="server" CssClass="input-xlarge"></asp:TextBox>

                        </div>
                        <div class="control-group">

                            <asp:TextBox ID="txtSubject" placeholder="Konu" runat="server" CssClass="input-xlarge"></asp:TextBox>

                        </div>
                        <div class="control-group">
                            Fotoğraf:
                            <asp:FileUpload ID="FileUpload1" CssClass="input-xlarge" runat="server" />


                        </div>
                        <div class="control-group">
                            <asp:TextBox ID="txtText" placeholder="Mesaj" TextMode="MultiLine" Height="100px" runat="server" CssClass="input-xlarge"></asp:TextBox>

                        </div>

                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        <div class="g-recaptcha" data-size="normal" data-type="image" data-sitekey="6LcowVsUAAAAAHjKHnijrclx_ZajCXd5_3M8ImSp"></div>
                        <asp:Button ID="btnSubmit" CssClass="shopBtn" runat="server" Text="Gönder" OnClick="btnSubmit_Click" />

                    </fieldset>
                </div>
            </div>
        </div>


    </div>

</asp:Content>

