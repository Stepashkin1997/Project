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
        if ($(this).parent().parent().attr('class') == 'add') {
            $(this).parent().parent().remove();
        }
        else {
            $(this).attr('map', commands.size);
            commands.set(lmap++, "DELETE FROM " + $("select#update").val() + " WHERE id=" + $(this).parent().parent().attr('id') + "; ")
            $(this).parent().parent().children("td").css('background-color', 'blue');
            $(this).attr('src', '/Content/img/plus.png');
            $(this).attr('class', 'recover');
        }
    });

    $('#table').on("click", ".recover", function () {
        $(this).parent().parent().children("td").css("background-color", "");
        $(this).attr('src', '/Content/img/minus.png');
        $(this).attr('class', 'delete');
        commands.delete(Number($(this).attr('map')));
    });

    $('#confirm').bind('click', function () {
        var b = false;
        $('#table').children('.add').each(function () {
            var params = "";
            var values = "";
            var i = 0;
            $(this).children('td').each(function () {
                i++;
                if (i == lrow) {
                    params += $(this).attr('id');
                    values += "'" + $(this).children('input').val() + "'";
                    if ($(this).children('input').val() == null) {
                        alert("Заполните ячейки полностью!");
                        b = true;
                        return;
                    }
                }
                else {
                    params += $(this).attr('id') + ",";
                    values += "'" + $(this).children('input').val() + "',";
                }
            })
            commands.set(lmap++, "INSERT INTO " + $("select#update").val() + "(" + params + ")" + " VALUES (" + values + "); ");
        });
        if (b)
            return;
        var com;
        commands.forEach(function (value) {
            com += value;
        });
        $.ajax({
            url: "/Update/Change/",
            type: "POST",
            data: {
                "commands": com
            },
            error: function (response) {
                alert("Server is fallen");
            }
        });
    });

    $('#add').bind('click', function () {
        $("#table").append("<tr class='add' id='" + length + "'>");
        for (var key in table[0]) {
            if (key == "id") {
                continue;
            }
            else {
                $("#" + length + "").append("<td id='" + key + "'></td>");
            }
        }
        $("#" + length + "").append("<th><img src='/Content/img/minus.png' class='delete'/></th>");
        length++;
        $(".delete").css('cursor', ' pointer');
    });

    $('#table').on("click", "td", function (e) {

        var t = e.target || e.srcElement;
        var val = $(this).text();
        $(this).html("<input type='text' value='" + val + "' name='" + $(this).attr('id') + "' id='" + $(this).attr('id') + "'/>");
        $(this).find('input').focus();
        $(this).find('input').blur(function (e) {
            if ($(this).parent().parent().attr('class') == 'add')
                return;
            if (val != $(this).val()) {
                var a = $(this).parent().parent().attr('id');
                $(this).attr('map', commands.size);
                commands.set(lmap++, "UPDATE " + $("select#update").val() + " SET " + $(this).attr('id') + "='" + $(this).val() + "' WHERE id=" + $(this).parent().parent().attr('id') + "; ")
                $(this).attr('readonly', true).removeAttr("id");
            }
            else {
                $(this).parent().html($(this).val());
            }
        });
    });
});

function onAjaxSuccess(data) {
    $("#add").empty();
    $("#table").empty();
    data = jQuery.parseJSON(data);
    table = data;
    $("#table").append("<caption><h1>" + $("select option:selected").html() + "</h1></caption>");
    $("#table").append("<tr id='title'>");
    for (var key in data[0]) {
        if (key == "id") {
            continue;
        }
        lrow++;
        $("#title").append("<th>" + key + "</th>");
    }
    $("#title").append("<th>delete</th>");
    length = data.length + 1;
    for (var i = 0; i < data.length; i++) {
        $("#table").append("<tr id='" + data[i].Id + "'>");

        for (var key in data[i]) {
            if (key == "id") {
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
}

