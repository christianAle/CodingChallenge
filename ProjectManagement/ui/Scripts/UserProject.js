function saveUserProject() {
    if ($('#Projects').val() != "" && $('#Users').val() != "" && $('#isActive').val() != "" && $('#AssignedDate').val()) {
        var data = {
            "ProjectId": $('#Projects').val(),
            "UserId": $('#Users').val(),
            "isActive": $('#isActive').val(),
            "AssignedDate": $('#AssignedDate').val()
        }

        $.ajax({
            url: "/UserProject/UserProject",
            type: 'POST',
            data: data,
            success: function (data) {
                $("#UserProject").data("kendoGrid").read();
            }
        });

    } else {
        alert("please complete the fileds");
    }
}

function onProjectsChange()
{
    var id = $("#Users").val();
    var grid = $("#projects").data("kendoGrid");
    $.ajax({
        url: "/UserProject/UserProject",
        type: 'POST',
        data: id,
        success: function (data) {
            var grid = $("#projects").data("kendoGrid");
            grid.setDataSource(dataSource);
            grid.setDataSource(data);
            //$("#projects").data("kendoGrid").read();
        }
    });
    
}

