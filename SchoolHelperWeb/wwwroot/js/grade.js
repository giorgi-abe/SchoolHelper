function AddGrade() {
    var radios = document.getElementsByName("gradingtype");
    var fromdata[] = {};
    fromdata["info"] = document.getElementById("info").value;
    fromdata["mark"] = document.getElementById("mark").value;
    fromdata["day"] = document.getElementById("day").value;
    fromdata["month"] = document.getElementById("month").value;
    fromdata["year"] = document.getElementById("year").value;
        for (var i = 0, length = radios.length; i < length; i++) {
        if (radios[i].checked) {
            fromdata["gradingtype"] = radios[i].value;
            break;
        }
    }

    var table = document.getElementById("table").getElementsByTagName("tbody")[0];
    var newRow = table.insertRow(table.length);
    cel1 = newRow.insertCell(0);
    cel1.innerHTML = fromdata.info;
    cel2 = newRow.insertCell(1);
    cel2.innerHTML = fromdata.mark;
    cel3 = newRow.insertCell(2);
    cel3.innerHTML = fromdata.gradingtype;
    cel4 = newRow.insertCell(3);
    cel4.innerHTML = new Date(fromdata.year, fromdata.month, fromdata.day);
    cel5 = newRow.insertCell(4);
    cel5.innerHTML = ' <a href="@Url.Action("Delete", "GradeController",new { item.Id, @ViewBag.Message  })">< svg width = "1em" height = "1em" viewBox = "0 0 16 16" class="bi bi-trash" fill = "currentColor" xmlns = "http://www.w3.org/2000/svg" ><path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" /><path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4L4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" /></svg ></a >';

    document.getElementById("info").value == "";
    document.getElementById("mark").value == "";
    document.getElementById("day").value == "";
    document.getElementById("month").value == "";
    document.getElementById("year").value == "";
}