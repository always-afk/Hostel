function AddClick() {

    HideMainButons()
    ShowSecButtons()

    var table = document.getElementById("table")
    var newRow = document.createElement("tr")

    var head = document.getElementById("headtable")

    var cells = head.cells

    var sizesWidth = []
    var sizesHeight = []
    var placeholders = []

    for (var cell of cells) {
        sizesWidth.push(cell.clientWidth)
        sizesHeight.push(cell.clientHeight)
        placeholders.push(cell.innerHTML)
    }

    for (var i = 0; i < 10; i++) {
        
        var newTdCell = document.createElement("td")
        newTdCell.style.padding = "0"
        newTdCell.style.background = "white"
        var newInput = document.createElement("input")
        if (i == 0) {
            var firstInputCell = newInput
        }
        newInput.type = Text
        //fullName.style.width = parseInt(sizes[i])-17 + "px"

        //Styles:
        newInput.style.width = parseInt(sizesWidth[i]) -1 + "px"
        newInput.style.height = parseInt(sizesHeight[i])  + "px"
        newInput.style.border = "0"
        newInput.style.padding="8px"
        newInput.style.borderRadius = "0px"
        newInput.style.background = "rgba(90,100, 205, 0.05)"
        
        


        //
        newInput.placeholder = placeholders[i]
        newTdCell.appendChild(newInput)
        newRow.appendChild(newTdCell)
        newInput.select()
    }

    SetAddButtons()

    table.appendChild(newRow)
    firstInputCell.select()
}

function DeleteClick() {

    HideMainButons()

    SetDelButtons()

    var elems = table.getElementsByTagName('tr');

    var curr = 0

    for (var el of elems) {
        if (curr != 0) {
            var e = document.createElement('td');
            e.style.padding = "0"
            e.style.margin = "0"
            e.style.width = el.offsetHeight -1  + "px"
            e.style.height = el.offsetHeight -1 + "px"
            e.style.verticalAlign = "middle"
            e.style.textAlign = "center"
            var box = document.createElement("input");

            box.type = "checkbox"
            box.style.padding = "0"
            box.style.margin = "0"
            box.style.width = parseInt(el.offsetHeight) - 8 + "px"
            box.style.height = parseInt(el.offsetHeight) - 8 + "px"
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