$(function () {
    Sum();
    })

function Sum() {
    $inputs = $("input[type='checkbox']")
    $inputs.on("change", function () {
        var sum = 0;
        $inputs.each(function () {
            if (this.checked) {
                sum += parseFloat($(this).data("price"))
            }
        })
        $("#lblPrice").html(sum.toFixed(2));
    })
}
