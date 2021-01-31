<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Scala.ServiceClasses.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body style="width: 99%; padding: 10px;">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-4" runat="server" id="grpPersonen">
                <div class="card">
                    <div class="card-header">Personen</div>
                    <div class="card-body">
                        <div class="row">
                            <div class="btn-group">
                                <asp:Button ID="btnNieuw" runat="server" Text="Nieuw" CssClass="btn btn-light" OnClick="btnNieuw_Click" />
                                <asp:Button ID="btnWijzig" runat="server" Text="Wijzig" CssClass="btn btn-light" OnClick="btnWijzig_Click" />
                                <asp:Button ID="btnWis" runat="server" Text="Wis" CssClass="btn btn-light" OnClick="btnWis_Click" />

                            </div>
                        </div>
                        <div class="row">
                            <asp:ListBox ID="lstPersonen" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="lstPersonen_SelectedIndexChanged"
                                Style="width: 99%; height: 600px;"></asp:ListBox>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-8" runat="server" id="grpDetails">
                <div class="card">
                    <div class="card-header">Details</div>
                    <div class="card-body">
                        <div class="row">
                            <asp:Button ID="btnBewaren" runat="server" Text="Bewaren" CssClass="btn btn-success" OnClick="btnBewaren_Click" />
                            <asp:Button ID="btnAnnuleren" runat="server" Text="Annuleren" CssClass="btn btn-danger" OnClick="btnAnnuleren_Click" />

                        </div>
                        <div class="row">
                            <table class="table table-bordered">
                                <tbody>
                                    <tr>
                                        <th class="col-4">Naam</th>
                                        <td class="col-8">
                                            <asp:TextBox ID="txtNaam" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Voornaam</th>
                                        <td>
                                            <asp:TextBox ID="txtVoornaam" runat="server" CssClass="form-control"></asp:TextBox></td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Geboortedatum</th>
                                        <td>

                                            <asp:Calendar ID="dtpGeboortedatum" runat="server"></asp:Calendar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Leeftijd</th>
                                        <td>
                                            <asp:Label ID="lblLeeftijd" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <th>Geslacht</th>
                                        <td>
                                            <asp:RadioButton ID="rdbMan" runat="server" Text=" Man" CssClass="form-control" GroupName="geslacht" />
                                            <asp:RadioButton ID="rdbVrouw" runat="server" Text=" Vrouw" CssClass="form-control" GroupName="geslacht" />
                                        </td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </form>
</body>
</html>
