
function SuccessMessage(SuccessTxt) {
    Swal.fire({
        icon: 'success',
        title: 'وضعیت ثبت',
        text: SuccessTxt,
    });
}
function ErrorMessage(ErrorTxt) {
    Swal.fire({
        icon: 'error',
        title: 'خطا',
        text: ErrorTxt,
    });
}

$(document).on("keyup", "#UserNameChange", function () {
    BindGrid();
});
$(document).on("keyup", "#FirstNameChange", function () {
    BindGrid();
});
$(document).on("keyup", "#LastNameChange", function () {
    BindGrid();
});
$(document).on("change", "#RoleIDChange", function () {
    BindGrid();
});


$(document).on("keyup", "#RoleNameChange", function () {
    BindGrid();
});


$(document).on("keyup", "#ProjectActionNameChange", function () {
    BindGrid();
});


$(document).on("keyup", "#PersianTitleChange", function () {
    BindGrid();
});
$(document).on("change", "#ProjectControllerIDChange", function () {
    BindGrid();
});

$(document).on("keyup", "#ProjectControllerNameChange", function () {
    BindGrid();
});
$(document).on("change", "#ProjectAreaIDChange", function () {
    BindGrid();
});

$(document).on("keyup", "#AreaNameChange", function () {
    BindGrid();
});
