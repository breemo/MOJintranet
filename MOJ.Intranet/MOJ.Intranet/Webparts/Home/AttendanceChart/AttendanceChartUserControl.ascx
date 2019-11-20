<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttendanceChartUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.AttendanceChart.AttendanceChartUserControl" %>

<!-- <script src="https://npmcdn.com/moment@2.14.1"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script> -->

<!-- <script>
    $(function () {
        const ctx = document.getElementById('myChart').getContext('2d');
        let years = ["January", "February", "March", "April", "May", "June", "July"];
        let times = ["11:46:07", "11:41:14", "15:55:26", "12:14:58", "16:14:55", "11:54:04", "10:28:29"];

        let data = years.map((year, index) => ({
            x: moment(`${year}-01-01`),
            y: moment(`1970-02-01 ${times[index]}`).valueOf()
        }));

        let bckColors = ["#2a91ff", "#2a91ff", "#2a91ff", "#2a91ff", "#2a91ff", "#2a91ff", "#2a91ff", "#129864", "#326812", "#215984"];

        let myChart = new Chart(ctx, {
            type: 'line',

            data: {

                labels: ["الاحد", "الاثنين", "الثلاثاء", "الثلاثاء", "الخميس", "الجمعه", "السبت"],
                datasets: [
                    {
                        label: "Time",
                        backgroundColor: 'rgba(53, 127, 234, 0.4)',
                        pointBackgroundColor: bckColors,
                        data: data,
                        pointBorderWidth: 2,
                        pointRadius: 3,
                        pointHoverRadius: 9,
                        fill: true,
                        lineTension: 0.1,
                        backgroundColor: "rgba(39,143,255,0.4)",
                        borderColor: "rgba(39,143,255,1)",

                    }


                ]
            },
            options: {
                label: {
                    font: {
                        family: 'Cairo, sans-serif',
                    }
                },

                legend: {
                    display: false,
                    labels: {
                        display: false,
                        fontFamily: 'Cairo, sans-serif',
                    }
                },
                scales: {


                    xAxes: [{
                        gridLines: {

                        },
                        pointLabels: {
                            fontFamily: 'Cairo, sans-serif',
                        }
                    }],

                    yAxes: [
                        {


                            type: 'linear',
                            position: 'left',
                            ticks: {
                                min: moment('1970-02-01 06:00:00').valueOf(),
                                max: moment('1970-02-01 17:00:00').valueOf(),
                                stepSize: 3.6e+6,
                                beginAtZero: false,
                                callback: value => {
                                    let date = moment(value);
                                    if (date.diff(moment('1970-02-01 18:59:59'), 'minutes') === 0) {
                                        return null;
                                    }

                                    return date.format('h A');
                                }
                            }
                        }
                    ]
                }
            }
        });
    });

</script> -->

<h4 class="TitleHead">
    <asp:Literal runat="server" Text="<%$ Resources:Resource, AttendeesChartTitle%>" /></h4>

<div class="blockbox minhe">

    <div class="chaid">
        <!-- <canvas id="myChart" style="max-width: 100% !important" width="500" height="260"></canvas>-->

        <img src="/Ar/PublishingImages/download.png" runat="server" id="Chartimg" style="width:100%;max-height:250px !important;">
    </div>

</div>


