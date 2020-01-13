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
    $("#Users").data("kendoDropDownList").value();
    $.ajax({
        url: "/GetUserProjects/UserProject",
        type: 'POST',
        data: "",
        success: function (data) {
            var grid = $("#Projects").data("kendoGrid");
            grid.setDataSource(dataSource);
            grid.setDataSource(data);
            //$("#projects").data("kendoGrid").read();
        }
    });
    
}

function onDataBound(e) {
    e.sender.value("--");
}

