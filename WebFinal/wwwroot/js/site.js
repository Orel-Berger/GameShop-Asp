
function CRateOut(r) {
    for (var i = 1; i <= r; i++) {
        $("#span" + i).attr('class', 'starGlow');
    }
}

function CRateOver(r) {
    for (var i = 1; i <= r; i++) {
        $("#span" + i).attr('class', 'starFade');
    }
}
function CRateCilck(r) {
    $("#lblRating").val(r);
    for (var i = 1; i <= r; i++) {
        $("#span" + i).attr('class', 'starGlow');
    }
    for (var i = r + 1; i <= 5; i++) {
        $("#span" + i).attr('class', 'starFade');
    }
}
function CRateSelected() {
    var rating = $("#lblRating").val();
    for (var i = r + 1; i <= 5; i++) {
        $("#span" + i).attr('class', 'starGlow');
    }
}

function VerifyRating() {
    var rating = $("#lblRating").val();
    var tex = $("#txtArticleComment").val();
    if (rating == "0" || tex == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please select Rating and write decription',
        });
        return false;
    }
}
