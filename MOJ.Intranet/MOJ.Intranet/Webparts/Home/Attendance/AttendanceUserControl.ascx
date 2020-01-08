<%@ Assembly Name="MOJ.Intranet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f6919f05ce3f6f90" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttendanceUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.Attendance.AttendanceUserControl" %>


<asp:HiddenField ClientIDMode="Static" runat="server" ID="LeaveBalanceValue" />
<asp:HiddenField ClientIDMode="Static" runat="server" ID="SickLeaveBalanceValue" />
<asp:HiddenField ClientIDMode="Static" runat="server" ID="PermitLeaveBalanceValue" />

<h4 class="TitleHead">
    <asp:Literal runat="server" Text="<%$ Resources:Resource, Attendees%>" /></h4>
<div class="blockbox minhe bgx">

    <div class="boxline">
    </div>

    <div class="d-flex row">

        <div class="col-md-4">


            <div class="chart" style="width: 100%">
            </div>
            <div class="titilxde"> <asp:Literal runat="server" Text="<%$ Resources:Resource, SickVacation%>" /></div>
        </div>


        <div class="col-md-4">


            <div class="chart" style="width: 100%">
            </div>
            <div class="titilxde"> <asp:Literal runat="server" Text="<%$ Resources:Resource, VacationBalance%>" /></div>
        </div>

        <div class="col-md-4">


            <div class="chart" style="width: 100%">
            </div>
            <div class="titilxde"> <asp:Literal runat="server" Text="<%$ Resources:Resource, Departure%>" /></div>
        </div>




    </div>
</div>

<script>



    // Very simple JS for updating the text when a radio button is clicked
    const INPUTS = document.querySelectorAll('#smileys input');

    function updateValue(e) {
        document.querySelector('#result').innerHTML = e.target.value;
    }

    INPUTS.forEach(el => el.addEventListener('click', (e) => updateValue(e)));
    </script>


    <script>
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement('script');
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(hm, s);
        })();

        var bgColor = '#fff';
        var Leave = LeaveBalanceValue.value;
        var SickLeave = LeaveBalanceValue.value;
        var PermitLeave = LeaveBalanceValue.value;


        //alert(Leave);
        if (Leave == "")
            Leave = "0.0";

        if (SickLeave == "")
            SickLeave = "0.0";

        if (PermitLeave == "")
            PermitLeave = "0.0";


        var containers = document.getElementsByClassName('chart');
        var options = [{
            series: [{ // الاجازات المرضية
                type: 'liquidFill',
                data: [SickLeave, {
                    value: SickLeave,
                    direction: 'left',
                    itemStyle: {
                        color: '#219e78',

                    }
                },],

                itemStyle: {
                    shadowBlur: 0,
                    color: '#1a876a',
                },

                radius: '70%',
                phase: 0,
                period: 5000,

                radius: '70%',
                outline: {
                    show: false
                },
                backgroundStyle: {
                    borderColor: '#008470',
                    borderWidth: 2,
                    color: bgColor,
                    shadowColor: 'rgba(0, 0, 0, 0.4)',
                    shadowBlur: 20
                },


                shape: 'path://M67.54998149518622 10.999999999999998Q86.60254037844386 0 105.65509926170151 10.999999999999998L154.15252187363006 39Q173.20508075688772 50 173.20508075688772 72L173.20508075688772 128Q173.20508075688772 150 154.15252187363006 161L105.65509926170151 189Q86.60254037844386 200 67.54998149518622 189L19.052558883257653 161Q0 150 0 128L0 72Q0 50 19.052558883257653 39Z',



                outline: {
                    show: false,
                    borderWidth: 2,
                    backgroundColor: 'red',
                },

                label: {


                    show: true,
                    color: '#303030',
                    insideColor: '303030',
                    fontSize: 15,
                    fontWeight: 'bold',
                },



            }]
        }, {
            series: [{ //رصيد الاجازات
                type: 'liquidFill',
                data: [Leave, {
                    value: Leave,
                    direction: 'left',
                    itemStyle: {
                        color: '#bb3232',

                    }
                },],

                itemStyle: {
                    shadowBlur: 0,
                    color: '#a32327',
                },

                radius: '70%',
                phase: 0,
                period: 5000,

                shape: 'path://M67.54998149518622 10.999999999999998Q86.60254037844386 0 105.65509926170151 10.999999999999998L154.15252187363006 39Q173.20508075688772 50 173.20508075688772 72L173.20508075688772 128Q173.20508075688772 150 154.15252187363006 161L105.65509926170151 189Q86.60254037844386 200 67.54998149518622 189L19.052558883257653 161Q0 150 0 128L0 72Q0 50 19.052558883257653 39Z',


                backgroundStyle: {
                    borderColor: '#bf3333',
                    borderWidth: 2,
                    color: bgColor,
                    shadowColor: 'rgba(0, 0, 0, 0.4)',
                    shadowBlur: 20
                },
                outline: {
                    show: false
                },

                label: {


                    show: true,
                    color: '#303030',
                    insideColor: '#303030',
                    fontSize: 15,
                    fontWeight: 'bold',
                },

            }]

        }, {
            series: [{ //المغادرات
                type: 'liquidFill',
                data: [PermitLeave, {
                    value: PermitLeave,
                    direction: 'left',
                    itemStyle: {
                        color: '#728aeb',
                        //color: '#fff',
                    }
                },],

                itemStyle: {
                    shadowBlur: 0,
                    //color: '#596fc6',
                    color: '#fff',
                },

                radius: '70%',
                phase: 0,
                period: 5000,

                outline: {
                    show: false
                },

                shape: 'path://M67.54998149518622 10.999999999999998Q86.60254037844386 0 105.65509926170151 10.999999999999998L154.15252187363006 39Q173.20508075688772 50 173.20508075688772 72L173.20508075688772 128Q173.20508075688772 150 154.15252187363006 161L105.65509926170151 189Q86.60254037844386 200 67.54998149518622 189L19.052558883257653 161Q0 150 0 128L0 72Q0 50 19.052558883257653 39Z',


                backgroundStyle: {
                    borderColor: '#569de5',
                    borderWidth: 2,
                    color: bgColor,
                    shadowColor: 'rgba(0, 0, 0, 0.3)',
                    shadowBlur: 20,
                },

                label: {

                    show: true,
                    color: '#303030',
                    insideColor: '#303030',
                    fontSize: 15,
                    fontWeight: 'bold',
                },
                outline: {
                    show: false,


                },

            }]

        }, {


        }];

        var charts = [];
        for (var i = 0; i < options.length; ++i) {
            var chart = echarts.init(containers[i]);

            if (i > 0) {
                options[i].series[0].silent = true;
            }
            chart.setOption(options[i]);
            chart.setOption({
                baseOption: options[i],
                media: [{
                    query: {
                        maxWidth: 300
                    },
                    option: {
                        series: [{
                            label: {
                                fontSize: 26
                            }
                        }]
                    }
                }]
            });

            charts.push(chart);
        }

        window.onresize = function () {
            for (var i = 0; i < charts.length; ++i) {
                charts[i].resize();
            }
        };

        setInterval(update, 3000);

        function update() {
            var data = [];
            var last = 1;
            for (var i = 0; i < 4; ++i) {
                last = Math.floor(last * (Math.random() * 0.5 + 0.5)
                    * 100) / 100;
                data.push(last);
            }
            charts[1].setOption({
                series: [{
                    data: data
                }]
            });
        }
    </script>
    <script>

        var presets = window.chartColors;
        var utils = Samples.utils;
        var inputs = {
            min: 7,
            max: 9,
            count: 7,
            decimals: 0,
            continuity: 1
        };

        function generateData(config) {
            return utils.numbers(utils.merge(inputs, config || {}));
        }

        function generateLabels(config) {
            return utils.months(utils.merge({
                count: inputs.count,
                section: 10
            }, config || {}));
        }

        var options = {


            maintainAspectRatio: false,
            spanGaps: false,
            elements: {
                line: {
                    tension: 0.000001
                }
            },
            plugins: {
                filler: {
                    propagate: true
                }
            },
            scales: {
                xAxes: [{
                    ticks: {
                        autoSkip: false,
                        maxRotation: 0
                    }
                }]
            },


        };

        [false, 'origin', 'start', 'end'].forEach(function (boundary, index) {

            // reset the random seed to generate the same data for all charts
            utils.srand(8);

            new Chart('chart-' + index, {
                type: 'line',
                data: {
                    labels: generateLabels(),
                    datasets: [{
                        backgroundColor: utils.transparentize(presets.blue),
                        borderColor: presets.blue,
                        data: generateData(),
                        label: 'Dataset',
                        fill: boundary
                    }]
                },
                options: utils.merge(options, {
                    title: {
                        text: ' ' + boundary,
                        display: false,
                    },
                    legend: {
                        labels: {
                            FontFamily: 'tahoma'
                        }
                    },


                    tooltips: {
                        yAlign: 'bottom',
                        callbacks: {
                            label: function (tooltipItem, data) {
                                return tooltipItem.yLabel;
                            }
                        },

                        backgroundColor: '#278fff',
                        FontFamily: 'tahoma',
                        titleFontSize: 12,
                        titleFontWeight: 'regular',
                        titleSpacing: 10,
                        titleFontColor: '#fff',

                        bodyFontSize: 14,
                        bodyFontColor: '#fff',

                        caretSize: 8,
                        caretPadding: 8,
                        cornerRadius: 7,
                        bodySpacing: 10,
                    }

                })
            });
        });


        function toggleSmooth(btn) {
            var value = btn.classList.toggle('btn-on');
            Chart.helpers.each(Chart.instances, function (chart) {
                chart.options.elements.line.tension = value ? 0.4 : 0.000001;
                chart.update();
            });
        }

        function randomize() {
            var seed = utils.rand();
            Chart.helpers.each(Chart.instances, function (chart) {
                utils.srand(seed);

                chart.data.datasets.forEach(function (dataset) {
                    dataset.data = generateData();
                });

                chart.update();
            });
        }


    </script>
