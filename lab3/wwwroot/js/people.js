const uri = "https://localhost:44331/api";
const controller = "/Persons";

let personList = null;

$(document).ready(function () {
    getData();
});

function getCount(data) {
    const siteElement = $("#counter");
    
    if (data) {
        if (data > 1) {
            siteElement.text("Tutaj pojawi się lista imion i nazwisk");
        } else {
            siteElement.text("Tutaj pojawi się imię i nazisko");
        }
    } else {
        siteElement.text("Brak Osób");
    }
}

function getData() {
    $.ajax({
        type: "GET",
        url: uri + controller,
        cache: false,
        success: function (data) {
            const tableBody = $("#persons");
            $(tableBody).empty();
            getCount(data.length);
            
            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td class=\"table-pos\"></td>").text("Pozycja " + (key+1) + ":"))
                    .append($("<td class=\"table-data\"></td>").text(item.name + " " + item.surname))
                    .append(
                        $("<td class=\"table-button\"></td>").append(
                            $("<button class=\"table-button-button\">Edycja</button>").on("click", function () {
                                editItem(item.id);
                            })
                        )
                    )
                    .append(
                        $("<td class=\"table-button\"></td>").append(
                            $("<button class=\"table-button-button\">Usuń</button>").on("click", function () {
                                deleteItem(item.id);
                            })
                        )
                    );
                tr.appendTo(tableBody);
            });
            personList = data;
        }
    });
}

function addItem() {
    const item = {
        name: $("#add-name").val(),
        surname: $("#add-surname").val()
    };
    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri + controller,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Wystąpił problem!");
        },
        success: function (result) {
            getData();
            $("#add-name").val("");
            $("#add-surname").val("");
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + "/" + id + controller,
        type: "DELETE",
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    closeInput("#form-add")
    openInput("#form-edit")
    $.each(personList, function (key, item) {
        if (item.id === id) {
            $("#edit-name").val(item.name);
            $("#edit-surname").val(item.surname);
            $("#edit-id").val(item.id);
        }
    });
}

function updateItem() {
    const item = {
        id: $("#edit-id").val(),
        name: $("#edit-name").val(),
        surname: $("#edit-surname").val(),
        isAwesome: $("#edit-isAwesome").is(":checked")
    };
    $.ajax({
        type: "PUT",
        accepts: "application/json",
        url: uri + controller,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Wystąpił problem!");
        },
        success: function (result) {
            getData();
            closeInput("#form-edit");
            openInput("#form-add")
        }
    });
}

function closeInput(inputName) {
    $(inputName).css({ display: "none" });
}

function openInput(inputName) {
    $(inputName).css({ display: "block" });
}