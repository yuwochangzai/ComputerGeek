<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="weixin._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #5a5e63;
        }

        .center {
            margin-top:150px;
            text-align: center;
        }

        #imgCode {
            height: 300px;
            width: 300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="center">
                <img src="Image/qrcode.jpg" alt="扫一扫加入微信关注" id="imgCode" />
            </div>
        </div>
    </form>
</body>
</html>
