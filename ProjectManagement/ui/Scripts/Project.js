function saveProject() {
    if ($('#StartDate').val() != "" && $('#EndDate').val() != "" && $('#Credits').val()!= "" ) {
        var data = {
            "StartDate": $('#StartDate').val(),
            "EndDate": $('#EndDate').val(),
            "Credits": $('#Credits').val() 
        }

        $.ajax({
            url: "/Project/Project",
            type: 'POST',
            data: data,
            success: function (data) {
                $("#Projects").data("kendoGrid").read();
            }
        });

    } else {
        alert("don't send");
    }
}