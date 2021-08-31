function AddClick() {

    HideMainButons()
    ShowSecButtons()

    var table = document.getElementById("table")
    var newRow = document.createElement("tr")

    var head = document.getElementById("headtable")

    var c = head.cells

    var sizes = []
    var ph = []

    for (var i of c) {
        sizes.push(i.clientWidth)
        ph.push(i.innerHTML)
    }

    for (var i = 0; i < 10; i++) {
        
        var newFullNameElem = document.createElement("td")
        var fullName = document.createElement("input")
        fullName.type = Text
        fullName.style.width = sizes[i] + "px"
        fullName.placeholder = ph[i]
        newFullNameElem.appendChild(fullName)
        newRow.appendChild(newFullNameElem)
    }

    SetAddButtons()

    table.appendChild(newRow)
}

function DeleteClick() {

    HideMainButons()

    SetDelButtons()

    var elems = table.getElementsByTagName('tr');

    var curr = 0

    for (var el of elems) {
        if (curr != 0) {
            var e = document.createElement('td');
            var box = document.createElement("input");
            box.type = "checkbox"
            box.style.height = el.style.height + "px"
            e.appendChild(box)
            el.appendChild(e)
        }
        curr += 1
        
    }

    ShowSecButtons()    
}

function ApplyDelete() {
    var rows = table.getElementsByTagName('tr');
    var rowstoDel = []
    var cur = 0
    for (var row of rows) {
        if (cur > 0) {
            var tbs = row.cells
            var box = tbs[10].childNodes[0]
            if (box.checked) {
                rowstoDel.push(row)
            }
        }
        cur +=1
    }

    for (var e of rowstoDel) {
        e.remove()
    }

    CancelDelete()
}

function CancelDelete() {
    var rows = table.getElementsByTagName('tr');
    var cellsToDel = []
    let cur = 0

    for (var row of rows) {
        if (cur > 0) {
            cellsToDel.push(row.cells[row.cells.length - 1])
        }
        else {
            cur += 1
        }
    }

    for (var cell of cellsToDel) {
        cell.remove()
    }

    SetNullButtons()
    HideSecButtons()
    ShowMainButtons()
}

function CancelAdd() {
    var rows = table.getElementsByTagName('tr');
    var lastrow = rows[rows.length - 1]
    lastrow.remove()

    SetNullButtons()
    HideSecButtons()
    ShowMainButtons()
}

function ApplyAdd() {
    var rows = table.getElementsByTagName('tr')
    var lastrow = rows.item(rows.length - 1)
    var newRow = document.createElement("tr")

    for (var i of lastrow.cells) {
        var td = document.createElement('td')
        td.innerHTML = i.childNodes[0].value
        newRow.appendChild(td)
    }

    lastrow.remove()
    table.appendChild(newRow)

    ShowMainButtons()
    HideSecButtons()
}


function HideMainButons() {
    var add = document.getElementById("AddButton")
    var edit = document.getElementById("EditButton")
    var del = document.getElementById("DeleteButton")
    add.hidden = true
    edit.hidden = true
    del.hidden = true
}

function ShowMainButtons() {
    var add = document.getElementById("AddButton")
    var edit = document.getElementById("EditButton")
    var del = document.getElementById("DeleteButton")
    add.hidden = false
    edit.hidden = false
    del.hidden = false
}

function HideSecButtons() {
    var ap = document.getElementById("ApplyButton")
    var can = document.getElementById("CancelButton")
    ap.hidden = true
    can.hidden = true
}

function ShowSecButtons() {
    var ap = document.getElementById("ApplyButton")
    var can = document.getElementById("CancelButton")
    ap.hidden = false
    can.hidden = false
}

function SetDelButtons() {
    var apply = document.getElementById("ApplyButton")
    apply.onclick = ApplyDelete

    var del = document.getElementById("CancelButton")
    del.onclick = CancelDelete
}

function SetAddButtons() {
    var apply = document.getElementById("ApplyButton")
    apply.onclick = ApplyAdd

    var del = document.getElementById("CancelButton")
    del.onclick = CancelAdd
}

function SetNullButtons() {
    var apply = document.getElementById("ApplyButton")
    apply.onclick = null

    var del = document.getElementById("CancelButton")
    del.onclick = null
}

function SaveButton() {


}