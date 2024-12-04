using Common.BLL;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Common.ReportHandle
{
    public class CreateReportHelper
    {
        /// <summary>
        /// 生成报告方法
        /// </summary>
        /// <param name="barcode">条码号</param>
        /// <param name="sampleid">样本号</param>
        /// <param name="DRBindInfo">绑定DT信息</param>
        /// <returns></returns>
        public static XtraReport ReportCreate(string barcode, string sampleid, DataRow DRBindInfo)
        {
            string FileStringa = "Ly8vIDxYUlR5cGVJbmZvPg0KLy8vICAgPEFzc2VtYmx5RnVsbE5hbWU+RGV2RXhwcmVzcy5YdHJhUmVwb3J0cy52MjAuMSwgVmVyc2lvbj0yMC4xLjMuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhPC9Bc3NlbWJseUZ1bGxOYW1lPg0KLy8vICAgPEFzc2VtYmx5TG9jYXRpb24+QzpcV2luZG93c1xNaWNyb3NvZnQuTmV0XGFzc2VtYmx5XEdBQ19NU0lMXERldkV4cHJlc3MuWHRyYVJlcG9ydHMudjIwLjFcdjQuMF8yMC4xLjMuMF9fYjg4ZDE3NTRkNzAwZTQ5YVxEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnYyMC4xLmRsbDwvQXNzZW1ibHlMb2NhdGlvbj4NCi8vLyAgIDxUeXBlTmFtZT5EZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlh0cmFSZXBvcnQ8L1R5cGVOYW1lPg0KLy8vICAgPExvY2FsaXphdGlvbj56aC1DTjwvTG9jYWxpemF0aW9uPg0KLy8vICAgPFZlcnNpb24+MjAuMTwvVmVyc2lvbj4NCi8vLyAgIDxSZXNvdXJjZXM+DQovLy8gICAgIDxSZXNvdXJjZSBOYW1lPSJYdHJhUmVwb3J0U2VyaWFsaXphdGlvbi5YdHJhUmVwb3J0Ij4NCi8vLyB6c3J2dmdFQUFBQ1JBQUFBYkZONWMzUmxiUzVTWlhOdmRYSmpaWE11VW1WemIzVnlZMlZTWldGa1pYSXNJRzF6WTI5eWJHbGlMQ0JXWlhKemFXOXVQVFF1TUM0d0xqQXNJRU4xYkhSMWNtVTlibVYxZEhKaGJDd2dVSFZpYkdsalMyVjVWRzlyWlc0OVlqYzNZVFZqTlRZeE9UTTBaVEE0T1NOVGVYTjBaVzB1VW1WemIzVnlZMlZ6TGxKMWJuUnBiV1ZTWlhOdmRYSmpaVk5sZEFJQUFBQUFBQUFBQUFBQUFGQkJSRkJCUkZDMEFBQUE8L1Jlc291cmNlPg0KLy8vICAgPC9SZXNvdXJjZXM+DQovLy8gPC9YUlR5cGVJbmZvPg0KbmFtZXNwYWNlIFh0cmFSZXBvcnRTZXJpYWxpemF0aW9uIHsNCiAgICANCiAgICBwdWJsaWMgY2xhc3MgWHRyYVJlcG9ydCA6IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWHRyYVJlcG9ydCB7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5Ub3BNYXJnaW5CYW5kIFRvcE1hcmdpbjsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLkRldGFpbEJhbmQgRGV0YWlsOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQgc3ViRGV0YWlsOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuQm90dG9tTWFyZ2luQmFuZCBCb3R0b21NYXJnaW47DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5SZXBvcnRIZWFkZXJCYW5kIFJlcG9ydEhlYWRlcjsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0IHN1YlJlcG9ydEhlYWRlcjsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlBhZ2VIZWFkZXJCYW5kIFBhZ2VIZWFkZXI7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCBzdWJUaXRsZTsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0IHN1YlBhZ2VIZWFkZXI7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5Hcm91cEhlYWRlckJhbmQgR3JvdXBIZWFkZXI7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCBzdWJHcm91cEhlYWRlcjsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLkdyb3VwRm9vdGVyQmFuZCBHcm91cEZvb3RlcjsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0IHN1Ykdyb3VwRm9vdGVyOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuUmVwb3J0Rm9vdGVyQmFuZCBSZXBvcnRGb290ZXI7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCBzdWJSZXBvcnRGb290ZXI7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5QYWdlRm9vdGVyQmFuZCBQYWdlRm9vdGVyOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQgc3ViUGFnZUZvb3RlcjsNCiAgICAgICAgcHJpdmF0ZSBTeXN0ZW0uUmVzb3VyY2VzLlJlc291cmNlTWFuYWdlciBfcmVzb3VyY2VzOw0KICAgICAgICBwcml2YXRlIHN0cmluZyBfcmVzb3VyY2VTdHJpbmc7DQogICAgICAgIHB1YmxpYyBYdHJhUmVwb3J0KCkgew0KICAgICAgICAgICAgdGhpcy5fcmVzb3VyY2VTdHJpbmcgPSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlNlcmlhbGl6YXRpb24uWFJSZXNvdXJjZU1hbmFnZXIuR2V0UmVzb3VyY2VGb3IoIlh0cmFSZXBvcnRTZXJpYWxpemF0aW9uLlh0cmFSZXBvcnQiKTsNCiAgICAgICAgICAgIHRoaXMuSW5pdGlhbGl6ZUNvbXBvbmVudCgpOw0KICAgICAgICB9DQogICAgICAgIHByaXZhdGUgU3lzdGVtLlJlc291cmNlcy5SZXNvdXJjZU1hbmFnZXIgcmVzb3VyY2VzIHsNCiAgICAgICAgICAgIGdldCB7DQogICAgICAgICAgICAgICAgaWYgKF9yZXNvdXJjZXMgPT0gbnVsbCkgew0KICAgICAgICAgICAgICAgICAgICB0aGlzLl9yZXNvdXJjZXMgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5TZXJpYWxpemF0aW9uLlhSUmVzb3VyY2VNYW5hZ2VyKHRoaXMuX3Jlc291cmNlU3RyaW5nKTsNCiAgICAgICAgICAgICAgICB9DQogICAgICAgICAgICAgICAgcmV0dXJuIHRoaXMuX3Jlc291cmNlczsNCiAgICAgICAgICAgIH0NCiAgICAgICAgfQ0KICAgICAgICBwcml2YXRlIHZvaWQgSW5pdGlhbGl6ZUNvbXBvbmVudCgpIHsNCiAgICAgICAgICAgIHRoaXMuVG9wTWFyZ2luID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuVG9wTWFyZ2luQmFuZCgpOw0KICAgICAgICAgICAgdGhpcy5EZXRhaWwgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5EZXRhaWxCYW5kKCk7DQogICAgICAgICAgICB0aGlzLkJvdHRvbU1hcmdpbiA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLkJvdHRvbU1hcmdpbkJhbmQoKTsNCiAgICAgICAgICAgIHRoaXMuUmVwb3J0SGVhZGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuUmVwb3J0SGVhZGVyQmFuZCgpOw0KICAgICAgICAgICAgdGhpcy5QYWdlSGVhZGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuUGFnZUhlYWRlckJhbmQoKTsNCiAgICAgICAgICAgIHRoaXMuR3JvdXBIZWFkZXIgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5Hcm91cEhlYWRlckJhbmQoKTsNCiAgICAgICAgICAgIHRoaXMuR3JvdXBGb290ZXIgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5Hcm91cEZvb3RlckJhbmQoKTsNCiAgICAgICAgICAgIHRoaXMuUmVwb3J0Rm9vdGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuUmVwb3J0Rm9vdGVyQmFuZCgpOw0KICAgICAgICAgICAgdGhpcy5QYWdlRm9vdGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuUGFnZUZvb3RlckJhbmQoKTsNCiAgICAgICAgICAgIHRoaXMuc3ViRGV0YWlsID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQoKTsNCiAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0SGVhZGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQoKTsNCiAgICAgICAgICAgIHRoaXMuc3ViVGl0bGUgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCgpOw0KICAgICAgICAgICAgdGhpcy5zdWJQYWdlSGVhZGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQoKTsNCiAgICAgICAgICAgIHRoaXMuc3ViR3JvdXBIZWFkZXIgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCgpOw0KICAgICAgICAgICAgdGhpcy5zdWJHcm91cEZvb3RlciA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0KCk7DQogICAgICAgICAgICB0aGlzLnN1YlJlcG9ydEZvb3RlciA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0KCk7DQogICAgICAgICAgICB0aGlzLnN1YlBhZ2VGb290ZXIgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCgpOw0KICAgICAgICAgICAgKChTeXN0ZW0uQ29tcG9uZW50TW9kZWwuSVN1cHBvcnRJbml0aWFsaXplKSh0aGlzKSkuQmVnaW5Jbml0KCk7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIFRvcE1hcmdpbg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLlRvcE1hcmdpbi5IZWlnaHRGID0gMTJGOw0KICAgICAgICAgICAgdGhpcy5Ub3BNYXJnaW4uTmFtZSA9ICJUb3BNYXJnaW4iOw0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICAvLyBEZXRhaWwNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgdGhpcy5EZXRhaWwuQ29udHJvbHMuQWRkUmFuZ2UobmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJDb250cm9sW10gew0KICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5zdWJEZXRhaWx9KTsNCiAgICAgICAgICAgIHRoaXMuRGV0YWlsLkhlaWdodEYgPSA0NC4yMDgzMkY7DQogICAgICAgICAgICB0aGlzLkRldGFpbC5OYW1lID0gIkRldGFpbCI7DQogICAgICAgICAgICB0aGlzLkRldGFpbC5TbmFwTGluZVBhZGRpbmcgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuUGFkZGluZ0luZm8oMCwgMCwgMCwgMCwgMTAwRik7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIEJvdHRvbU1hcmdpbg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLkJvdHRvbU1hcmdpbi5IZWlnaHRGID0gMTJGOw0KICAgICAgICAgICAgdGhpcy5Cb3R0b21NYXJnaW4uTmFtZSA9ICJCb3R0b21NYXJnaW4iOw0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICAvLyBSZXBvcnRIZWFkZXINCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgdGhpcy5SZXBvcnRIZWFkZXIuQ29udHJvbHMuQWRkUmFuZ2UobmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJDb250cm9sW10gew0KICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5zdWJSZXBvcnRIZWFkZXJ9KTsNCiAgICAgICAgICAgIHRoaXMuUmVwb3J0SGVhZGVyLkhlaWdodEYgPSA0NC4yMDgzMkY7DQogICAgICAgICAgICB0aGlzLlJlcG9ydEhlYWRlci5OYW1lID0gIlJlcG9ydEhlYWRlciI7DQogICAgICAgICAgICB0aGlzLlJlcG9ydEhlYWRlci5TbmFwTGluZVBhZGRpbmcgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuUGFkZGluZ0luZm8oMCwgMCwgMCwgMCwgMTAwRik7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIFBhZ2VIZWFkZXINCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgdGhpcy5QYWdlSGVhZGVyLkNvbnRyb2xzLkFkZFJhbmdlKG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSQ29udHJvbFtdIHsNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuc3ViVGl0bGUsDQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLnN1YlBhZ2VIZWFkZXJ9KTsNCiAgICAgICAgICAgIHRoaXMuUGFnZUhlYWRlci5IZWlnaHRGID0gNDMuMjQ5OTdGOw0KICAgICAgICAgICAgdGhpcy5QYWdlSGVhZGVyLk5hbWUgPSAiUGFnZUhlYWRlciI7DQogICAgICAgICAgICB0aGlzLlBhZ2VIZWFkZXIuU25hcExpbmVQYWRkaW5nID0gbmV3IERldkV4cHJlc3MuWHRyYVByaW50aW5nLlBhZGRpbmdJbmZvKDAsIDAsIDAsIDAsIDEwMEYpOw0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICAvLyBHcm91cEhlYWRlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLkdyb3VwSGVhZGVyLkNvbnRyb2xzLkFkZFJhbmdlKG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSQ29udHJvbFtdIHsNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuc3ViR3JvdXBIZWFkZXJ9KTsNCiAgICAgICAgICAgIHRoaXMuR3JvdXBIZWFkZXIuSGVpZ2h0RiA9IDQ0LjIwODMyRjsNCiAgICAgICAgICAgIHRoaXMuR3JvdXBIZWFkZXIuTmFtZSA9ICJHcm91cEhlYWRlciI7DQogICAgICAgICAgICB0aGlzLkdyb3VwSGVhZGVyLlNuYXBMaW5lUGFkZGluZyA9IG5ldyBEZXZFeHByZXNzLlh0cmFQcmludGluZy5QYWRkaW5nSW5mbygwLCAwLCAwLCAwLCAxMDBGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gR3JvdXBGb290ZXINCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgdGhpcy5Hcm91cEZvb3Rlci5Db250cm9scy5BZGRSYW5nZShuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUkNvbnRyb2xbXSB7DQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLnN1Ykdyb3VwRm9vdGVyfSk7DQogICAgICAgICAgICB0aGlzLkdyb3VwRm9vdGVyLkhlaWdodEYgPSA0NC4yMDgzMkY7DQogICAgICAgICAgICB0aGlzLkdyb3VwRm9vdGVyLk5hbWUgPSAiR3JvdXBGb290ZXIiOw0KICAgICAgICAgICAgdGhpcy5Hcm91cEZvb3Rlci5TbmFwTGluZVBhZGRpbmcgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuUGFkZGluZ0luZm8oMCwgMCwgMCwgMCwgMTAwRik7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIFJlcG9ydEZvb3Rlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLlJlcG9ydEZvb3Rlci5Db250cm9scy5BZGRSYW5nZShuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUkNvbnRyb2xbXSB7DQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLnN1YlJlcG9ydEZvb3Rlcn0pOw0KICAgICAgICAgICAgdGhpcy5SZXBvcnRGb290ZXIuSGVpZ2h0RiA9IDIyLjMzMzM0RjsNCiAgICAgICAgICAgIHRoaXMuUmVwb3J0Rm9vdGVyLk5hbWUgPSAiUmVwb3J0Rm9vdGVyIjsNCiAgICAgICAgICAgIHRoaXMuUmVwb3J0Rm9vdGVyLlNuYXBMaW5lUGFkZGluZyA9IG5ldyBEZXZFeHByZXNzLlh0cmFQcmludGluZy5QYWRkaW5nSW5mbygwLCAwLCAwLCAwLCAxMDBGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gUGFnZUZvb3Rlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLlBhZ2VGb290ZXIuQ29udHJvbHMuQWRkUmFuZ2UobmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJDb250cm9sW10gew0KICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5zdWJQYWdlRm9vdGVyfSk7DQogICAgICAgICAgICB0aGlzLlBhZ2VGb290ZXIuSGVpZ2h0RiA9IDI1LjIwODQxRjsNCiAgICAgICAgICAgIHRoaXMuUGFnZUZvb3Rlci5OYW1lID0gIlBhZ2VGb290ZXIiOw0KICAgICAgICAgICAgdGhpcy5QYWdlRm9vdGVyLlNuYXBMaW5lUGFkZGluZyA9IG5ldyBEZXZFeHByZXNzLlh0cmFQcmludGluZy5QYWRkaW5nSW5mbygwLCAwLCAwLCAwLCAxMDBGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gc3ViRGV0YWlsDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuc3ViRGV0YWlsLkxvY2F0aW9uRmxvYXQgPSBuZXcgRGV2RXhwcmVzcy5VdGlscy5Qb2ludEZsb2F0KDBGLCAwRik7DQogICAgICAgICAgICB0aGlzLnN1YkRldGFpbC5OYW1lID0gInN1YkRldGFpbCI7DQogICAgICAgICAgICB0aGlzLnN1YkRldGFpbC5TaXplRiA9IG5ldyBTeXN0ZW0uRHJhd2luZy5TaXplRig4MjUuOTk5OUYsIDQ0LjIwODMyRik7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIHN1YlJlcG9ydEhlYWRlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLnN1YlJlcG9ydEhlYWRlci5Mb2NhdGlvbkZsb2F0ID0gbmV3IERldkV4cHJlc3MuVXRpbHMuUG9pbnRGbG9hdCgwLjAwMDE3NDg0MDNGLCAwRik7DQogICAgICAgICAgICB0aGlzLnN1YlJlcG9ydEhlYWRlci5OYW1lID0gInN1YlJlcG9ydEhlYWRlciI7DQogICAgICAgICAgICB0aGlzLnN1YlJlcG9ydEhlYWRlci5TaXplRiA9IG5ldyBTeXN0ZW0uRHJhd2luZy5TaXplRig4MjUuOTk5OEYsIDQ0LjIwODMyRik7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIHN1YlRpdGxlDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuc3ViVGl0bGUuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDBGKTsNCiAgICAgICAgICAgIHRoaXMuc3ViVGl0bGUuTmFtZSA9ICJzdWJUaXRsZSI7DQogICAgICAgICAgICB0aGlzLnN1YlRpdGxlLlNpemVGID0gbmV3IFN5c3RlbS5EcmF3aW5nLlNpemVGKDgyNS45OTk3RiwgMjNGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gc3ViUGFnZUhlYWRlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLnN1YlBhZ2VIZWFkZXIuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDIzRik7DQogICAgICAgICAgICB0aGlzLnN1YlBhZ2VIZWFkZXIuTmFtZSA9ICJzdWJQYWdlSGVhZGVyIjsNCiAgICAgICAgICAgIHRoaXMuc3ViUGFnZUhlYWRlci5TaXplRiA9IG5ldyBTeXN0ZW0uRHJhd2luZy5TaXplRig4MjUuOTk5OUYsIDIwLjI0OTk3Rik7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIHN1Ykdyb3VwSGVhZGVyDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuc3ViR3JvdXBIZWFkZXIuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDBGKTsNCiAgICAgICAgICAgIHRoaXMuc3ViR3JvdXBIZWFkZXIuTmFtZSA9ICJzdWJHcm91cEhlYWRlciI7DQogICAgICAgICAgICB0aGlzLnN1Ykdyb3VwSGVhZGVyLlNpemVGID0gbmV3IFN5c3RlbS5EcmF3aW5nLlNpemVGKDgyNS45OTk5RiwgNDQuMjA4MzJGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gc3ViR3JvdXBGb290ZXINCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgdGhpcy5zdWJHcm91cEZvb3Rlci5Mb2NhdGlvbkZsb2F0ID0gbmV3IERldkV4cHJlc3MuVXRpbHMuUG9pbnRGbG9hdCgwRiwgMEYpOw0KICAgICAgICAgICAgdGhpcy5zdWJHcm91cEZvb3Rlci5OYW1lID0gInN1Ykdyb3VwRm9vdGVyIjsNCiAgICAgICAgICAgIHRoaXMuc3ViR3JvdXBGb290ZXIuU2l6ZUYgPSBuZXcgU3lzdGVtLkRyYXdpbmcuU2l6ZUYoODI1Ljk5OTlGLCA0NC4yMDgzMkYpOw0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICAvLyBzdWJSZXBvcnRGb290ZXINCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgdGhpcy5zdWJSZXBvcnRGb290ZXIuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDBGKTsNCiAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0Rm9vdGVyLk5hbWUgPSAic3ViUmVwb3J0Rm9vdGVyIjsNCiAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0Rm9vdGVyLlNpemVGID0gbmV3IFN5c3RlbS5EcmF3aW5nLlNpemVGKDgyNS45OTk5RiwgMjIuMzMzMzRGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gc3ViUGFnZUZvb3Rlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLnN1YlBhZ2VGb290ZXIuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDBGKTsNCiAgICAgICAgICAgIHRoaXMuc3ViUGFnZUZvb3Rlci5OYW1lID0gInN1YlBhZ2VGb290ZXIiOw0KICAgICAgICAgICAgdGhpcy5zdWJQYWdlRm9vdGVyLlNpemVGID0gbmV3IFN5c3RlbS5EcmF3aW5nLlNpemVGKDgyNS45OTk5RiwgMjQuNDE2NjdGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gWHRyYVJlcG9ydA0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLkJhbmRzLkFkZFJhbmdlKG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLkJhbmRbXSB7DQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLlRvcE1hcmdpbiwNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuRGV0YWlsLA0KICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5Cb3R0b21NYXJnaW4sDQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLlJlcG9ydEhlYWRlciwNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuUGFnZUhlYWRlciwNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuR3JvdXBIZWFkZXIsDQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLkdyb3VwRm9vdGVyLA0KICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5SZXBvcnRGb290ZXIsDQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLlBhZ2VGb290ZXJ9KTsNCiAgICAgICAgICAgIHRoaXMuTWFyZ2lucyA9IG5ldyBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5NYXJnaW5zKDEyLCAxMiwgMTIsIDEyKTsNCiAgICAgICAgICAgIHRoaXMuTmFtZSA9ICJYdHJhUmVwb3J0IjsNCiAgICAgICAgICAgIHRoaXMuUGFnZUhlaWdodCA9IDExMDA7DQogICAgICAgICAgICB0aGlzLlBhZ2VXaWR0aCA9IDg1MDsNCiAgICAgICAgICAgIHRoaXMuVmVyc2lvbiA9ICIyMC4xIjsNCiAgICAgICAgICAgICgoU3lzdGVtLkNvbXBvbmVudE1vZGVsLklTdXBwb3J0SW5pdGlhbGl6ZSkodGhpcykpLkVuZEluaXQoKTsNCiAgICAgICAgfQ0KICAgIH0NCn0NCg==";

            XtraReport commonReport = new XtraReport();
            byte[] arr = Convert.FromBase64String(FileStringa);
            Stream stream = new MemoryStream(arr);
            commonReport.LoadLayout(stream);
            commonReport.Margins = new System.Drawing.Printing.Margins(12, 12, 12, 12);
            if (!Convert.IsDBNull(DRBindInfo["paperKindNO"]))
            {
                string paperKindNO = DRBindInfo["paperKindNO"].ToString();
                if (paperKindNO == "1")
                    commonReport.PaperKind = System.Drawing.Printing.PaperKind.A5;//判断纸张的大小
                if (paperKindNO == "2")
                    commonReport.PaperKind = System.Drawing.Printing.PaperKind.A4;//判断纸张的大小
                if (paperKindNO == "3")
                    commonReport.PaperKind = System.Drawing.Printing.PaperKind.A3;//判断纸张的大小
            }
            else
            {
                commonReport.PaperKind = System.Drawing.Printing.PaperKind.A4;//判断纸张的大小
            }
            int Subwith = commonReport.PageWidth - 24;
            if (!Convert.IsDBNull(DRBindInfo["reportLandscape"]))
                commonReport.Landscape = Convert.ToBoolean(DRBindInfo["reportLandscape"]);


            XRSubreport subReportHeader = commonReport.FindControl("subReportHeader", true) as XRSubreport;
            XRSubreport subTitle = commonReport.FindControl("subTitle", true) as XRSubreport;
            XRSubreport subPageHeader = commonReport.FindControl("subPageHeader", true) as XRSubreport;
            XRSubreport subGroupHeader = commonReport.FindControl("subGroupHeader", true) as XRSubreport;
            XRSubreport subDetail = commonReport.FindControl("subDetail", true) as XRSubreport;
            XRSubreport subGroupFooter = commonReport.FindControl("subGroupFooter", true) as XRSubreport;
            XRSubreport subReportFooter = commonReport.FindControl("subReportFooter", true) as XRSubreport;
            XRSubreport subPageFooter = commonReport.FindControl("subPageFooter", true) as XRSubreport;


            ReportHeaderBand reportHeader = commonReport.FindControl("ReportHeader", true) as ReportHeaderBand;
            PageHeaderBand pageHeader = commonReport.FindControl("PageHeader", true) as PageHeaderBand;
            GroupHeaderBand groupHeader = commonReport.FindControl("GroupHeader", true) as GroupHeaderBand;
            DetailBand detail = commonReport.FindControl("Detail", true) as DetailBand;
            GroupFooterBand groupFooter = commonReport.FindControl("GroupFooter", true) as GroupFooterBand;
            ReportFooterBand reportFooter = commonReport.FindControl("ReportFooter", true) as ReportFooterBand;
            PageFooterBand pageFooter = commonReport.FindControl("PageFooter", true) as PageFooterBand;

            //ReportHeaderNO

            if (!Convert.IsDBNull(DRBindInfo["reportHeaderNO"]))
            {
                string ReportHeaderNO = DRBindInfo["reportHeaderNO"].ToString();
                if (ReportHeaderNO != "")
                {


                    reportHeader.Visible = true;
                    reportHeader.BorderWidth = 0;
                    subReportHeader.Visible = true;
                    subReportHeader.SnapLineMargin = PaddingInfo.Empty;



                    if (ReportCommData.DTReportSrouceInfo.Select($"no='{ReportHeaderNO}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{ReportHeaderNO}'").CopyToDataTable();
                        if (barcode != null && sampleid != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}'and state=1";
                                        DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}' and state=1";
                                    DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arra = Convert.FromBase64String(FileString);
                            Stream streama = new MemoryStream(arra);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(streama);
                            xtraReport.PageWidth = Subwith;
                            subReportHeader.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    reportHeader.Visible = false;
                    subReportHeader.Visible = false;
                }
            }
            else
            {
                reportHeader.Visible = false;
                subReportHeader.Visible = false;
            }


            //ReportTile
            if (!Convert.IsDBNull(DRBindInfo["reportTileNO"]))
            {
                string GEReportTileNNO = DRBindInfo["reportTileNO"].ToString();
                if (GEReportTileNNO != "")
                {
                    pageHeader.BorderWidth = 0;
                    subTitle.Visible = true;
                    subPageHeader.Visible = true;
                    pageHeader.Padding = PaddingInfo.Empty;

                    //pageHeader.Visible = false;
                    //subPageHeader.Visible = false;
                    subPageHeader.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEReportTileNNO}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEReportTileNNO}'").CopyToDataTable();
                        if (barcode != null && sampleid != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}'and state=1";
                                        DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}' and state=1";
                                    DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arra = Convert.FromBase64String(FileString);
                            Stream streama = new MemoryStream(arra);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(streama);
                            xtraReport.PageWidth = Subwith;
                            subTitle.ReportSource = xtraReport;

                        }
                    }
                }
                else
                {
                    subTitle.Visible = false;
                    subPageHeader.LocationF = new PointF(0, 0);
                    pageHeader.HeightF = pageHeader.HeightF - subTitle.HeightF;
                }

            }
            else
            {
                subPageHeader.Visible = false;
                subPageHeader.LocationF = new PointF(0, 0);
                pageHeader.HeightF = pageHeader.HeightF - subTitle.HeightF;
            }


            //pageHeaderNO
            if (!Convert.IsDBNull(DRBindInfo["pageHeaderNO"]))
            {
                string GEpageHeaderNO = DRBindInfo["pageHeaderNO"].ToString();
                if (GEpageHeaderNO != "")
                {
                    pageHeader.BorderWidth = 0;
                    pageHeader.Visible = true;
                    subPageHeader.Visible = true;
                    pageHeader.Padding = PaddingInfo.Empty;
                    subPageHeader.SnapLineMargin = PaddingInfo.Empty;
                    //pageHeader.Visible = false;
                    //subPageHeader.Visible = false;
                    subPageHeader.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEpageHeaderNO}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEpageHeaderNO}'").CopyToDataTable();
                        if (barcode != null && sampleid != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}'and state=1";
                                        DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}' and state=1";
                                    DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arra = Convert.FromBase64String(FileString);
                            Stream streama = new MemoryStream(arra);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(streama);
                            xtraReport.PageWidth = Subwith;
                            subPageHeader.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    pageHeader.Visible = false;
                    subPageHeader.Visible = false;
                }

            }
            else
            {
                pageHeader.Visible = false;
                subPageHeader.Visible = false;
            }


            //GroupHeaderNO
            if (!Convert.IsDBNull(DRBindInfo["groupHeaderNO"]))
            {
                string GEGroupHeaderNO = DRBindInfo["groupHeaderNO"].ToString();
                if (GEGroupHeaderNO != "")
                {
                    groupHeader.Visible = true;
                    subGroupHeader.Visible = true;
                    subGroupHeader.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEGroupHeaderNO}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEGroupHeaderNO}'").CopyToDataTable();
                        if (barcode != null && sampleid != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}'and state=1";
                                        DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}' and state=1";
                                    DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arra = Convert.FromBase64String(FileString);
                            Stream streama = new MemoryStream(arra);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(streama);
                            xtraReport.PageWidth = Subwith;
                            subGroupHeader.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    groupHeader.Visible = false;
                    subGroupHeader.Visible = false;
                }


            }
            else
            {
                groupHeader.Visible = false;
                subGroupHeader.Visible = false;
            }


            //DetailNO
            if (!Convert.IsDBNull(DRBindInfo["detailNO"]))
            {
                string GEDetailNO = DRBindInfo["detailNO"].ToString();
                if (GEDetailNO != "")
                {
                    detail.Visible = true;
                    subDetail.Visible = true;
                    subDetail.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEDetailNO}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEDetailNO}'").CopyToDataTable();
                        if (barcode != null && sampleid != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}'and state=1";
                                        DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}' and state=1";
                                    DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arra = Convert.FromBase64String(FileString);
                            Stream streama = new MemoryStream(arra);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(streama);
                            xtraReport.PageWidth = Subwith;
                            subDetail.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    detail.Visible = false;
                    subDetail.Visible = false;
                }


            }
            else
            {
                detail.Visible = false;
                subDetail.Visible = false;
            }


            //GroupFooterNO
            if (!Convert.IsDBNull(DRBindInfo["groupFooterNO"]))
            {
                string GEGroupFooterNO = DRBindInfo["groupFooterNO"].ToString();
                if (GEGroupFooterNO != "")
                {


                    groupFooter.Visible = true;
                    subGroupFooter.Visible = true;

                    subGroupFooter.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEGroupFooterNO}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEGroupFooterNO}'").CopyToDataTable();
                        if (barcode != null && sampleid != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}'and state=1";
                                        DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}' and state=1";
                                    DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arra = Convert.FromBase64String(FileString);
                            Stream streama = new MemoryStream(arra);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(streama);
                            xtraReport.PageWidth = Subwith;
                            subGroupFooter.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    groupFooter.Visible = false;
                    subGroupFooter.Visible = false;
                }


            }
            else
            {
                groupFooter.Visible = false;
                subGroupFooter.Visible = false;
            }


            //ReportFooterNO
            if (!Convert.IsDBNull(DRBindInfo["reportFooterNO"]))
            {
                string GEReportFooterNO = DRBindInfo["reportFooterNO"].ToString();
                if (GEReportFooterNO != "")
                {
                    reportFooter.Visible = true;
                    subReportFooter.Visible = true;

                    subReportFooter.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEReportFooterNO}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEReportFooterNO}'").CopyToDataTable();
                        if (barcode != null && sampleid != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}'and state=1";
                                        DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}' and state=1";
                                    DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arra = Convert.FromBase64String(FileString);
                            Stream streama = new MemoryStream(arra);
                            //dataSet.Namespace = "dataInfo";
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(streama);
                            xtraReport.PageWidth = Subwith;
                            subReportFooter.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    reportFooter.Visible = false;
                    subReportFooter.Visible = false;
                    reportFooter.HeightF = 0;
                    subReportFooter.HeightF = 0;
                }
            }
            else
            {
                reportFooter.Visible = false;
                subReportFooter.Visible = false;
                reportFooter.HeightF = 0;
                subReportFooter.HeightF = 0;
            }


            //PageFooterNO
            if (!Convert.IsDBNull(DRBindInfo["pageFooterNO"]))
            {
                string GEPageFooterNO = DRBindInfo["pageFooterNO"].ToString();
                if (GEPageFooterNO != "")
                {
                    pageFooter.Visible = true;
                    subPageFooter.Visible = true;
                    subPageFooter.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEPageFooterNO}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEPageFooterNO}'").CopyToDataTable();
                        if (barcode != null && sampleid != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}'and state=1";
                                        DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{barcode}' and sampleID='{sampleid}' and state=1";
                                    DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arra = Convert.FromBase64String(FileString);
                            Stream streama = new MemoryStream(arra);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(streama);
                            xtraReport.PageWidth = Subwith;
                            subPageFooter.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    pageFooter.Visible = false;
                    subPageFooter.Visible = false;
                }


            }
            else
            {
                pageFooter.Visible = false;
                subPageFooter.Visible = false;
            }

            //commonReport.ShowPreview();
            return commonReport;
        }
    }
}
