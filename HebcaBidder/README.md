# HebcaBidder

## 引入河北CA签章ActiveX控件WebPDF2.dll
- 1.安装河北CA数字证书助手，WebPDF2.dll位于Program files/河北腾翔/
- 2.将ActiveX控件转成C#控件：打开Visual Studio命令行模式执行aximp WebPDF2.dll，得到AxWebPDFLib.dll
- 3.在项目中引入控件：右击“引用”添加引用，在COM下浏览找到AxWebPDFLib.dll添加

## 