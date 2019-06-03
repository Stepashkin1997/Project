var wrap;
var types = [];

//начальный метод скрипта
$(document).ready(function () {

    //ajax запрос таблиц
    $('#ok').bind('click', function () {
        var a = $("select#update").val();
        $.ajax({
            url: "/Update/Select/",
            type: "POST",
            dataType: "text",
            data: "table=" + a,
            success: onAjaxSuccess,
            error: function () {
                alert("Server is fallen");
            }
        });
    });


    //удаление по клику
    $('#table').on("click", ".delete", function () {
        if (confirm("Are you sure?")) {

            //SQL
            var del = "DELETE FROM " + $("select#update").val() + " WHERE id=" + $(this).parent().parent().attr('id') + "; ";

            //ajax отпрака удаления
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

    //вызов модального окна изменнений по клику на ячейку
    $('#table').on("click", "td", function () {
        modal.fadeIn();
        $("#ChangeForm").attr('action', "/Update/Edit" + $("select option:selected").html() + "/");
        $("#ActionHead").html("Edit");
        var ob = $(this).parent().children("td");
        var id = $(this).parent().attr("id");
        $('#hidden').val(id);
        var i = 0;

        //инициализация полей из строки
        $('#ActionForm').children("input").each(function () {
            $(this).attr('value', ob.eq(i++).text());
        });
    });

    //метод сортировки для ассоциативного массива
    function compare(a, b) {
        if (a.count < b.count) {
            return -1;
        }
        if (a.count > b.count) {
            return 1;
        }
        return 0;
    }

    //оброботчик события клика на Th, сортировка таблицы по столбцу
    $('#table').on("click", "th", function () {
        if ($(this).children("img").attr('class') == "delete" || $(this).html() =="delete")
            return;

        //отчиска класса предыдущего сортируемого
        $('.srt').removeAttr('class');
            
        //сортируемый столбец
        var search = $(this).html();
        $(this).attr('class','srt');

        var col = [];

        //формирование массива - id,count
        $('#table').children('tr:not(#title)').each(function () {
            var id = $(this).attr('id');
            var count = $(this).find("td#" + search).html();
            col.push({ id: id, count: count });
        });

        //сортировка
        col.sort(compare);
        if ($(this).attr('id') == 'srt') {
            col.reverse();
            $(this).removeAttr('id');
        }
        else {
            $(this).attr('id', 'srt');
        }

        //формирование нового порядка в таблице
        for (var i = 0; i < col.length; i++) {
            var id = col[i].id;
            $("#" + id).appendTo($("#table"));
        }
    });


});


//метод выполняющийся при успешном выполнении ajax запроса таблиц
function onAjaxSuccess(data) {
    //первоначальная отчистка
    $("#add").empty();
    $("#table").empty();
    $("#ActionForm").empty();

    //parse
    data = jQuery.parseJSON(data);

    $("#table").append("<caption><h1>" + $("select option:selected").html() + "</h1></caption>");

    //Формирование заголовка таблицы
    $("#table").append("<tr id='title'>");
    for (var key in data[0]) {
        if (key == "Id") {
            continue;
        }
        
        $("#title").append("<th>" + key + "</th>");
        $("#ActionForm").append("<h3>" + key + "</h3>");
        $("#ActionForm").append("<input type='text' name='" + key + "'>");
    }
    $('#ChangeForm').append("<input type='hidden' name='Id' id='hidden' value=''>");
    $("#ChangeForm").append("<input type='submit'>");
    $("#title").append("<th>delete</th>");

    //Заполнение таблицы
    for (var i = 0; i < data.length; i++) {
        //создание строки
        $("#table").append("<tr id='" + data[i].Id + "'>");

        //заполнение строки
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


    //вызов модального окна для добаления
    btn.on('click', function () {
        modal.fadeIn();
        $("#hidden").attr('value', '');
        $("#ChangeForm").attr('action', "/Update/Add" + $("select option:selected").html() + "/");
        $("#ActionHead").html("Add");
    });

    //закрытие модального окна
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

