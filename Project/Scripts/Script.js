var wrap;


var commands = new Map();
var length;
var table;
var lmap = commands.size;
var lrow = 0;
$(document).ready(function () {
    $('#ok').bind('click', function () {
        var a = $("select#update").val();
        $.ajax({
            url: "/Update/Select/",
            type: "POST",
            dataType: "text",
            data: "table=" + a,
            success: onAjaxSuccess,
            error: function (response) {
                alert("Server is fallen");
            }
        });
    });

    $('#table').on("click", ".delete", function () {
        if (confirm("Are you sure?")) {
            var del = "DELETE FROM " + $("select#update").val() + " WHERE id=" + $(this).parent().parent().attr('id') + "; ";
            $.ajax({
                url: "/Update/Delete/",
                type: "POST",
                dataType: "text",
                data: "command=" + del,
                success: function () {
                    $(this).parent().parent().remove();
                    alert("Delete");
                },
                error: function () {
                    alert("Server is fallen");
                }
            });
        } else;
    });


    $('#table').on("click", "td", function (e) {

        //var t = e.target || e.srcElement;
        //var val = $(this).text();
        //$(this).html("<input type='text' value='" + val + "' name='" + $(this).attr('id') + "' id='" + $(this).attr('id') + "'/>");
        //$(this).find('input').focus();
        //$(this).find('input').blur(function (e) {
        //    if ($(this).parent().parent().attr('class') == 'add')
        //        return;
        //    if (val != $(this).val()) {
        //        var a = $(this).parent().parent().attr('id');
        //        $(this).attr('map', commands.size);
        //        commands.set(lmap++, "UPDATE " + $("select#update").val() + " SET " + $(this).attr('id') + "='" + $(this).val() + "' WHERE id=" + $(this).parent().parent().attr('id') + "; ")
        //        $(this).attr('readonly', true).removeAttr("id");
        //    }
        //    else {
        //        $(this).parent().html($(this).val());
        //    }
        //});
    });
});

function onAjaxSuccess(data) {
    //первоначальная отчистка
    $("#add").empty();
    $("#table").empty();
    $("#AddForm").empty();

    //parse
    data = jQuery.parseJSON(data);
    table = data;


    $("#table").append("<caption><h1>" + $("select option:selected").html() + "</h1></caption>");
    $("#AddForm").attr('action', "Add" + $("select option:selected").html());

    $("#table").append("<tr id='title'>");
    for (var key in data[0]) {
        if (key == "Id") {
            continue;
        }
        lrow++;
        $("#title").append("<th>" + key + "</th>");
        $("#AddForm").append("<h3>" + key + "</h3>");
        $("#AddForm").append("<input type='text' name='" + key + "'>");
    }
    $("#AddForm").append("<input type='submit'/>");
    $("#title").append("<th>delete</th>");

    length = data.length + 1;
    for (var i = 0; i < data.length; i++) {
        $("#table").append("<tr id='" + data[i].Id + "'>");

        for (var key in data[i]) {
            if (key == "Id") {
                continue;
            }
            else {
                $("#" + data[i].Id + "").append("<td id='" + key + "'>" + (data[i])[key] + "</td>");
            }
        }
        $("#" + data[i].Id + "").append("<th><img src='/Content/img/minus.png' class='delete'/></th>");
    }
    $("#add").append("<img src='/Content/img/plus.png' id='plus'>");
    $("#add").css('cursor', ' pointer');
    $(".delete").css('cursor', ' pointer');

    wrap = $('#wrapper'),
        btn = $('#add'),
        modal = $('.cover, .modal, .content');

    btn.on('click', function () {
        modal.fadeIn();
    });

    // close modal
    $('.modal').click(function () {
        wrap.on('click', function (event) {
            var select = $('.content');
            if ($(event.target).closest(select).length)
                return;
            modal.fadeOut();
            wrap.unbind('click');
        });
    });
}
