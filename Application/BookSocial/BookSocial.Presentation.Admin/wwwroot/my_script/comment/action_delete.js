﻿$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    if (confirm('Are you sure want to delete comment with id = ' + id + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteComment?id=${id}`
    } else {
        return false
    }
})