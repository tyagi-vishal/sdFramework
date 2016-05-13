//var form;
//var Param = {};
var reqUrl;
function Addtitle() {
    $('.page-next').attr('Title', 'Next');
    $('.page-first').attr('Title', 'First');
    $('.page-last').attr('Title', 'Last');
    $('.page-pre').attr('Title', 'Previous');
}
function DateFormatter(value, row, index) {
    return [
     row.ModifiedDate = new Date(row.ModifiedDate).toLocaleDateString()
    ].join('');
}
function rowStyle(row, index) {
    var classes = ['active', 'success', 'info', 'warning', 'danger'];

    if (index % 2 === 0) {
        return {
            classes: classes[1]
        };
    }
    return {};
}
var $table = $("#Loggrid");
var chk = false;
function RefreshGrid() {
    document.getElementById("btnFilter").click();
}
function ShowMessage(type, message) {
    $messageData = $("<span>Information</span>");
    BootstrapDialog.show({
        title: $messageData,
        type: type,
        message: message,
        closable: true,
        closeByBackdrop: false,
        closeByKeyboard: false,
        buttons: [{
            label: 'Ok',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }]
    });
}
$(document).ready(function () {
    var Param = {};
    $("#btnFindAudit").click(function () {        
        Param.SearchText = $("#SearchText").val();
        Param.clickBtn = true;
        $('#Loggrid').bootstrapTable('refresh');   
    });


   // var $table = $("#Loggrid");


    reqUrl = $("#HiddenHostName").val();

    $('#Loggrid').bootstrapTable({
        //headers: headers,
        method: 'post',
        url: reqUrl,
        cache: true,
        height: 350,
        classes: 'table table-hover',
        striped: true,
        customParams: Param,
        pageNumber: 1,
        pagination: true,
        pageSize: 5,
        pageList: [5, 10, 20, 30],
        search: false,
        showColumns: true,
        showRefresh: false,
        sidePagination: 'server',
        minimumCountColumns: 2,
        showHeader: true,
        showFilter: false,
        smartDisplay: true,
        clickToSelect: true,
        rowStyle: rowStyle,
        toolbar: '#custom-toolbar',
        columns: [{
            field: 'ModuleName',
            title: 'Module Name',
            type: 'search',
            width: '400',

            sortable: true
        }, {
            field: 'FieldName',
            title: 'Field Name',
            type: 'search',
            width: '400',
            sortable: true,
        },
        {
            field: 'PreviousValue',
            title: 'Old Value',
            type: 'search',
            width: '400',
            sortable: true,
        },
        {
            field: 'NewValue',
            title: 'New Value',
            type: 'search',
            width: '400',
            sortable: true,
        },
        {
            field: 'ModifiedBy',
            title: 'Modified By',
            type: 'search',
            width: '400',
            sortable: true,
        },
        {
            field: 'ModifiedDate',
            title: 'Modified Date',
            type: 'search',
            formatter: DateFormatter,
            width: '400',
            sortable: true,
        }],
        onSubmit: function () {
            var data = $('#filter-bar').bootstrapTableFilter('GetLogList');
            console.log(data);
        },
        onLoadSuccess: function () {
            Addtitle();
        },
        onPageChange: function () {
            Addtitle();
        }
    });

   
});

function LoadSuccess() {
    //$("#btnMassUpdate").show();
    //$("#ddlactivate").show();
}




