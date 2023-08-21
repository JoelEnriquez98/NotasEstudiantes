<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notas.aspx.cs" Inherits="NotasEstudiante.Notas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Files/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Files/css/Styles.css" rel="stylesheet" />
    <title>Qualification notes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container p-3">
            <div class="row">
                <div class="col">
                    <div class="table-responsive">
                        <asp:GridView ID="GridViewNotes" CssClass="table table-bordered table-condensed table-responsive table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewNotes_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Carne" HeaderText="Carne"></asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido"></asp:BoundField>
                                <asp:TemplateField HeaderText="Tarea 1">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxEditHomeWork1" runat="server" Text='<%# Bind("T1") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBoxHomeWork1" runat="server" CssClass="form-control" Text='<%# Bind("T1") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tarea 2">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("T2") %>' ID="TextBoxEditHomeWork2"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="form-control" Text='<%# Bind("T2") %>' ID="TextBoxHomeWork2"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tarea 3">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("T3") %>' ID="TextBoxEditHomeWork3"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="form-control" Text='<%# Bind("T3") %>' ID="TextBoxHomeWork3"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parcial 1">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("P1") %>' ID="TextBoxEditShortTest1"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="form-control" Text='<%# Bind("P1") %>' ID="TextBoxShortTest1"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parcial 2">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("P2") %>' ID="TextBoxEditShortTest2"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="form-control" Text='<%# Bind("P2") %>' ID="TextBoxShortTest2"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parcial 3">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("P3") %>' ID="TextBoxEditShortTest3"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="form-control" Text='<%# Bind("P3") %>' ID="TextBoxShortTest3"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Zona" HeaderText="Zona"></asp:BoundField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Left"></RowStyle>

                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-lg-6">
                    <asp:Button ID="ButtonValidate" CssClass="btn btn-success btn-custom" runat="server" Text="Validar" />
                </div>
                <div class="text-center col-lg-6">
                    <asp:Button ID="ButtonSave" CssClass="btn btn-info btn-custom" runat="server" Text="Guardar" />
                </div>
            </div>

        </div>
    </form>
    <script src="Files/js/bootstrap.bundle.min.js"></script>
</body>
</html>
