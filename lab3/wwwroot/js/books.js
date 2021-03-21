const uri = "https://localhost:44331/api";
const controller = "/Books";

let personList = null;

$(document).ready(function () {
    getData();
});

function getCount(data) {
    const siteElement = $("#counter");
    
    if (data) {
        if (data > 1) {
            if (data < 5) {
                siteElement.text(data + " Książki w bazie");
            } else {
                siteElement.text(data + " Książek w bazie");
            }
        } else {
            siteElement.text("1 Książka w bazie");
        }
    } else {
        siteElement.text("Brak książek w bazie");
    }
}

function getData() {
    $.ajax({
        type: "GET",
        url: uri + controller,
        cache: false,
        success: function (data) {
            const tableBody = $("#books");
            $(tableBody).empty();
            getCount(data.length);
            
            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text("Książka " + (key+1) + ":"))
                    .append($("<td></td>").text(item.title))
                    .append($("<td></td>").text(item.datePublished))
                    .append(
                        $("<td></td>").append(
                            $("<button>Edycja</button>").on("click", function () {
                                editItem(item.id);
                            })
                        )
                    )
                    .append(
                        $("<td></td>").append(
                            $("<button>Usuń</button>").on("click", function () {
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
        title: $("#add-title").val(),
        datePublished: $("#add-date").val()
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
            $("#add-title").val("");
            $("#add-date").val("");
            backToTable();
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
    showEditForm();
    $.each(personList, function (key, item) {
        if (item.id === id) {
            $("#edit-title").val(item.title);
            $("#edit-date").val(item.datePublished);
            $("#edit-id").val(item.id);
        }
    });
}

function updateItem() {
    const item = {
        id: $("#edit-id").val(),
        title: $("#edit-title").val(),
        datePublished: $("#edit-date").val()
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
            backToTable();
        }
    });
}

function closeInput(inputName) {
    $(inputName).css({ display: "none" });
}

function openInput(inputName) {
    $(inputName).css({ display: "block" });
}

function showAddForm() {
    openInput("#button-back");
    closeInput("#button-add");

    openInput("#form-add");
    closeInput("#tabel");
}

function backToTable() {
    closeInput("#button-back");
    openInput("#button-add");

    closeInput("#form-edit");
    closeInput("#form-add");
    openInput("#tabel");
}

function showEditForm() {
    openInput("#button-back");
    closeInput("#button-add");

    openInput("#form-edit");
    closeInput("#tabel");
}