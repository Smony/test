﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationTest.Default" ViewStateMode="Disabled" ValidateRequest="false" %>

<%-- отключить ValidateRequest="false, что бы можно было вставлять теги --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test</title>
    <meta name="description" content="" />
    <meta name="keywords" content="" />

    <link href="css/style.css" rel="stylesheet" />
    <script src="js/script.js"></script>
    <!-- подключаем библиотеку онлайн через Google CDN -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/jquery-1.11.3.min.js"></script>
    <style>
        #wrap {
            width: 100%;
            height: auto;
            margin: 0 auto;
            /*border: 1px solid #808080;*/
        }

        .row1 {
            border: 1px solid #fff;
            width: 98%;
            height: 300px;
            margin: 5px auto;
            margin-top: 10px;
            margin-bottom: 10px;
        }

            .row1 > div {
                height: 250px;
                width: 500px;
                position: relative;
                top: 50%;
                left: 50%;
                margin-top: -125px;
                margin-left: -300px;
                padding-left: 50px;
                border: 1px solid #ccc;
                border-radius: 5px;
            }

        .color-red {
            color: red;
        }

        .color-green {
            color: green;
        }

        .row2 {
            /*border: 1px solid blue;*/
            width: 98%;
            height: auto;
            margin: 5px auto;
            margin-top: 10px;
            margin-bottom: 10px;
        }

            .row2 > div {
                width: 49%;
                height: auto;
                /*border: 1px solid red;*/
                float: left;
                margin-left: 5px;
                margin-top: 5px;
            }

        table, td {
            border: 1px solid #00F;
            font-size: 16px;
            border-collapse: collapse;
        }

        td {
            padding: 5px;
        }

        .row3 {
            border: 1px solid #00F;
            width: 98%;
            height: 200px;
            margin: 5px auto;
            margin-top: 100px;
        }

        .row4 {
            /*border: 1px solid #00F;*/
            width: 98%;
            height: auto;
            margin: 5px auto;
            margin-top: 100px;
        }

            .row4 > div {
                width: 49%;
                height: auto;
                /*border: 1px solid red;*/
                float: left;
                margin-left: 5px;
                margin-top: 5px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrap">
            <div class="row1">
                <div>
                    <p>
                        <asp:Label ID="Label1Name" runat="server" Text="Имя"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox1Name" runat="server" ViewStateMode="Disabled"></asp:TextBox>
                        &nbsp;&nbsp;
                    </p>
                    <p>
                        <asp:Label ID="Label2SurName" runat="server" Text="Фамилия"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="TextBox2SurName" runat="server" ViewStateMode="Disabled"></asp:TextBox>
                        &nbsp;&nbsp;
                    </p>
                    <p>
                        <asp:Label ID="Label3Age" runat="server" Text="Возрост"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox3Age" runat="server" ViewStateMode="Disabled"></asp:TextBox>
                        &nbsp;&nbsp;
                    </p>
                    <p>
                        <asp:Label ID="Label4Work" runat="server" Text="Работа"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox4Work" runat="server" ViewStateMode="Disabled"></asp:TextBox>
                    </p>
                    <p>
                        <input id="Button1Js" type="button" value="Отправить(javascript)" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2Asp" runat="server" Text="Отправить(Asp.Net)" OnClick="Button2Asp_Click" />
                    </p>
                    <p>
                        <asp:Label ID="Label5Error" runat="server" Text=""></asp:Label>
                    </p>
                </div>
            </div>

            <div class="row2">

                <div>
                    <asp:GridView ID="GridView1One" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Имя" SortExpression="name" />
                            <asp:BoundField DataField="surname" HeaderText="Фамилия" SortExpression="surname" />
                            <asp:BoundField DataField="age" HeaderText="Возрост" SortExpression="age" />
                            <asp:BoundField DataField="work" HeaderText="Работ" SortExpression="work" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [name], [surname], [age], [work] FROM [Person]"></asp:SqlDataSource>
                </div>

                <div>
                    <asp:PlaceHolder ID="PlaceHolder1One" runat="server"></asp:PlaceHolder>
                </div>

            </div>

            <br />
            <br />


            <div class="row3">
                <textarea runat="server" id="TextArea1" cols="20" rows="2"></textarea>
                &nbsp;&nbsp;&nbsp;&nbsp;
  
                <asp:RadioButton ID="RadioButton1" runat="server" value="1" GroupName="radio" Checked="true" />
                &nbsp;
                <span>с разметкой</span>

                <asp:RadioButton ID="RadioButton2" runat="server" value="2" GroupName="radio" />
                &nbsp;
                <span>без разметки</span>


                <asp:RadioButton ID="RadioButton3" runat="server" value="3" GroupName="radio" />
                &nbsp;
                <span>выполнение</span>


                &nbsp;&nbsp;&nbsp;&nbsp;
                <input id="Button3ShowJs" type="button" value="Показать(javascript)" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4ShowAsp" runat="server" Text="Показать(Asp.Net)" OnClick="Button4ShowAsp_Click" />
                <br />
                <br />
                <div id="show" runat="server"></div>
            </div>

            <br />
            <br />

            <div class="row4">
                <div>
                    <asp:PlaceHolder ID="PlaceHolder1Left" runat="server"></asp:PlaceHolder>
                </div>
                <div>
                    <asp:PlaceHolder ID="PlaceHolder2Right" runat="server"></asp:PlaceHolder>
                </div>
            </div>


        </div>
    </form>

    <script>
        $(document).ready(function () {
            //нажатие на кнопку Отправить(javascript)
            $('#Button1Js').click(function () {

                //данные будут переданы в виде объекта
                var obj = {
                    TextBox1Name: $('#TextBox1Name').val(),
                    TextBox2SurName: $('#TextBox2SurName').val(),
                    TextBox3Age: $('#TextBox3Age').val(),
                    TextBox4Work: $('#TextBox4Work').val()
                }

                $.ajax({
                    url: 'a.ashx',
                    type: 'POST',
                    dataType: 'json',
                    cache: false,
                    data: obj
                });

                //очистка полей ввода
                $('#TextBox1Name').val('');
                $('#TextBox2SurName').val('');
                $('#TextBox3Age').val('');
                $('#TextBox4Work').val('');

                //redirect
                window.location.replace(document.URL);

            });

            /*нажатие на кнопку Показать(javascript)"*/
            $('#Button3ShowJs').click(function () {
                var a = $('#TextArea1').val();
                //массив радиокнопок
                var araRadio = document.getElementsByName('radio');
                //перебираем массив радио-кнопок
                for (var i = 0; i < araRadio.length; i++) {
                    //если радио-кнопка выбрана
                    if (araRadio[i].checked) {
                        //с разметкой
                        if (araRadio[i].value == '1') {
                            $('#show').text(a);
                        }
                            //без разметки
                        else if (araRadio[i].value == '2') {
                            var search = /<\/?[^>]+>/g;
                            var replace = '';
                            var a = a.replace(search, replace);
                            $('#show').text(a);
                        }
                            //выполнение
                        else if (araRadio[i].value == '3') {
                            $('#show').append(a);
                        }
                    }
                }
            });

        });
    </script>

</body>
</html>

