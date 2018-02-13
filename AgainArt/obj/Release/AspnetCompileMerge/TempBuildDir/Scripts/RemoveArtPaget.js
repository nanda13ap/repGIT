

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

        $.ajax({
            type: 'post',
            url: '/artWork/Delete',
            data: { ids: selectedIDs },
            //contentType: 'application/json; charset=utf-8',
            //dataType: 'json',// tipo q espero q o servidor retorne
            success: function (data) {
                alert("foi");//$('#spanResults').text(data.join(','));
            },
            error: function (e) {
                //alert(e.arguments);
            }
        });

    });
});