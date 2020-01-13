function saveUser() {
    if ($('#FirstName').val() != "" && $('#LastName').val() != null) {
        var data = {
          "FirstName": $('#FirstName').val(),
          "LastName": $('#LastName').val()
        }

        $.ajax({
            url: "/User/User",
            type: 'POST',
            data:  data,
            success: function (data) {
                $("#Users").data("kendoGrid").read();
            }
        });

    } else {
        alert("please complete the fileds");
    }
}



