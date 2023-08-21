<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notas.aspx.cs" Inherits="NotasEstudiante.Notas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Files/css/bootstrap.min.css" rel="stylesheet" />
    <title>Qualification notes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="table-responsive">
                <asp:GridView ID="GridViewNotes" CssClass="table table-bordered table-condensed table-responsive table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewNotes_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Carne" HeaderText="Carne"></asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido"></asp:BoundField>
                        <asp:TemplateField HeaderText="Tarea 1">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("T1") %>' ID="TextBox1"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="form-control" Text='<%# Bind("T1") %>' ID="TextBoxHomeWork1"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tarea 2">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("T2") %>' ID="TextBox1"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="form-control" Text='<%# Bind("T2") %>' ID="TextBoxHomeWork2"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tarea 3">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("T3") %>' ID="TextBox1"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="form-control" Text='<%# Bind("T3") %>' ID="TextBoxHomeWork3"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="P1" HeaderText="Parcial 1"></asp:BoundField>
                        <asp:BoundField DataField="P2" HeaderText="Parcial 2"></asp:BoundField>
                        <asp:BoundField DataField="P3" HeaderText="Parcial 3"></asp:BoundField>
                        <asp:BoundField DataField="Zona" HeaderText="Zona"></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
    <script src="Files/js/bootstrap.bundle.min.js"></script>
</body>
</html>
