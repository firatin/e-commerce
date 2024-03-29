<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Eticaret.Yonet.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş</title>
       

    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css"/>
    
    <link rel="stylesheet" type="text/css" href="stylesheets/theme.css"/>
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css"/>

    <script src="lib/jquery-1.7.2.min.js" type="text/javascript"></script>

    <!-- Demo page code -->

    <style type="text/css">
        #line-chart {
            height:300px;
            width:800px;
            margin: 0px auto;
            margin-top: 1em;
        }
        .brand { font-family: georgia, serif; }
        .brand .first {
            color: #ccc;
            font-style: italic;
        }
        .brand .second {
            color: #fff;
            font-weight: bold;
        }
    </style>

  

    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../assets/ico/apple-touch-icon-144-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="../assets/ico/apple-touch-icon-114-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="../assets/ico/apple-touch-icon-72-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" href="../assets/ico/apple-touch-icon-57-precomposed.png"/>
  </head>
</head>
<body>
    <form id="form1" runat="server">
     <body class=""> 
  <!--<![endif]-->
    
    <div class="navbar">
        <div class="navbar-inner">
                <ul class="nav pull-right">
                    
                </ul>
                <a class="brand" href="../Default.aspx"><span class="second">Siteye Git</span></a>
        </div>
    </div>
    


    

    
        <div class="row-fluid">
    <div class="dialog">
        <div class="block">
            <p class="block-heading">Giriş</p>
            <div class="block-body">
                <form>
                    Mail Adresi: <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtMail" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtMail" runat="server" CssClass="span12"></asp:TextBox>
                    <label>Şifre: <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtSifre" ForeColor="Red"></asp:RequiredFieldValidator></label>
                    <asp:TextBox ID="txtSifre" runat="server" CssClass="span12" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="btnGiris" runat="server" CssClass="btn"  Text="Giriş Yap" OnClick="btnGiris_Click" />
                    <asp:Label ID="lblBilgi" runat="server" ForeColor="Red"></asp:Label>
                    <div class="clearfix"></div>
                </form>
            </div>
        </div>
        <p><a href="SifremiUnuttum.aspx">Şifremi Unuttum?</a></p>
    </div>
</div>


    


    <script src="lib/bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript">
        $("[rel=tooltip]").tooltip();
        $(function () {
            $('.demo-cancel-click').click(function () { return false; });
        });
    </script>
    
  </body>
    </form>
    
</body>
</html>
