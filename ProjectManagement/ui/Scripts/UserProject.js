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
        alert("don't send");
    }
}

