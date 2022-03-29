// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function RemoveCentral(btn) {
    //$(btn).closest('tr').remove()
    var t = document.getElementById('Central')
    var rows = t.getElementsByTagName('tr');
    if (rows.length == 2) {
        alert("Central Domain cannot have less than 1 row")
        return;
    }

    var btnIdx = btn.id.replaceAll('removeCentral-', '');
    var idofIsDeleted = btnIdx + "__IsCentralDeleted";

    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;


    document.getElementById(hidIsDelId).value = "true";

    $(btn).closest('tr').hide();
}

function AddCentral(btn) {
    //get the table id - select the table
    var table = document.getElementById('Central');
    //get the rows of the table
    var rowList = table.getElementsByTagName('tr');

    //get the last row's html code (actual last row)
    var rowCode = rowList[rowList.length - 1].outerHTML;


    //get the last row id - where to add the next row
    var hiddenLast = rowList.length - 2

    //index of the row to be added
    var hiddenRow = eval(hiddenLast) + 1;

    //set the value
    rowCode = rowCode.replaceAll('_' + hiddenLast + '_', '_' + hiddenRow + '_');
    rowCode = rowCode.replaceAll('[' + hiddenLast + ']', '[' + hiddenRow + ']');
    rowCode = rowCode.replaceAll('-' + hiddenLast, '-' + hiddenRow);

    //insert the row
    var newRow = table.insertRow();
    newRow.innerHTML = rowCode;

    var x = document.getElementByTagName("INPUT");

    for (var cnt = 0; cnt < x.length; cnt++) {
        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + hiddenRow + '_') > 0)
            x[cnt].value = '';

    }
}

function RemoveRegional(btn) {
    //$(btn).closest('tr').remove()
    var table = document.getElementById('Regional')
    var rows = table.getElementsByTagName('tr');
    if (rows.length == 2) {
        alert("Regional Domain cannot have less than 1 row")
        return;
    }



    var btnIdx = btn.id.replaceAll('removeRegional-', '');
    var idofIsDeleted = btnIdx + "__IsRegionalDeleted";

    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;

    document.getElementById(hidIsDelId).value = "true";

    $(btn).closest('tr').hide();
}

function AddRegional(btn) {
    //get the table id - select the table
    var table = document.getElementById('Regional');
    //get the rows of the table
    var rowList = table.getElementsByTagName('tr');

    //get the last row's html code (actual last row)
    var rowCode = rowList[rowList.length - 1].outerHTML;


    //get the last row id - where to add the next row
    var hiddenLast = rowList.length - 2

    //index of the row to be added
    var hiddenRow = eval(hiddenLast) + 1;

    //set the value
    rowCode = rowCode.replaceAll('_' + hiddenLast + '_', '_' + hiddenRow + '_');
    rowCode = rowCode.replaceAll('[' + hiddenLast + ']', '[' + hiddenRow + ']');
    rowCode = rowCode.replaceAll('-' + hiddenLast, '-' + hiddenRow);

    //insert the row
    var newRow = table.insertRow();
    newRow.innerHTML = rowCode;

    var x = document.getElementByTagName("INPUT");

    for (var cnt = 0; cnt < x.length; cnt++) {
        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + hiddenRow + '_') > 0)
            x[cnt].value = '';

    }
}


function RemoveLocal(btn) {
    //$(btn).closest('tr').remove()
    var table = document.getElementById('Local')
    var rows = table.getElementsByTagName('tr');
    if (rows.length == 2) {
        alert("Local Domain cannot have less than 1 row")
        return;
    }

    var btnIdx = btn.id.replaceAll('removeLocal-', '');
    var idofIsDeleted = btnIdx + "__IsLocalDeleted";

    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;

    document.getElementById(hidIsDelId).value = "true";

    $(btn).closest('tr').hide();


}

function AddLocal(btn) {
    //get the table id - select the table
    var table = document.getElementById('Local');
    //get the rows of the table
    var rowList = table.getElementsByTagName('tr');

    //get the last row's html code (actual last row)
    var rowCode = rowList[rowList.length - 1].outerHTML;


    //get the last row id - where to add the next row
    var hiddenLast = rowList.length - 2

    //index of the row to be added
    var hiddenRow = eval(hiddenLast) + 1;

    //set the value
    rowCode = rowCode.replaceAll('_' + hiddenLast + '_', '_' + hiddenRow + '_');
    rowCode = rowCode.replaceAll('[' + hiddenLast + ']', '[' + hiddenRow + ']');
    rowCode = rowCode.replaceAll('-' + hiddenLast, '-' + hiddenRow);

    //insert the row
    var newRow = table.insertRow();
    newRow.innerHTML = rowCode;

    var x = document.getElementByTagName("INPUT");

    for (var cnt = 0; cnt < x.length; cnt++) {
        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + hiddenRow + '_') > 0)
            x[cnt].value = '';

    }

}
