

$(document).ready(function () {
    $("#ckbAll").change(function () {  //"select all" change
        $(".checkbox").prop('checked', $(this).prop("checked")); //change all ".checkbox" checked status
    });

    //".checkbox" change
    $('.checkbox').change(function () {
        //uncheck "select all", if one of the listed checkbox item is unchecked
        if (false == $(this).prop("checked")) { //if this item is unchecked
            $("#ckbAll").prop('checked', false); //change "select all" checked status to false
        }
        //check "select all" if all checkbox items are checked
        if ($('.checkbox:checked').length == $('.checkbox').length) {
            $("#ckbAll").prop('checked', true);
        }
    });


    $("#btnDelete").click(function () {
        var selectedIDs = new Array();
        $('.checkbox:checked').each(function () {
            selectedIDs.push($(this).val());
            //}
        });

        alert(selectedIDs);
        var options = {};
        options.url = "@Url.Action('Delete','ArtWork')";
        options.type = "POST";
        options.data = JSON.stringify(selectedIDs);
        options.contentType = "application/json";
        options.dataType = "json";
        options.success = function (msg) {
            alert(msg);
        };
        options.error = function (response) {
            alert("Server returned status code " + response + ".  Try again later. ");
            alert("Error while deleting the records!");
        };
        $.ajax(options);

    });
});