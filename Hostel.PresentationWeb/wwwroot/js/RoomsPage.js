//Handlers
function ClickAdd() {

}

function ClickEdit() {

}

function ClickCancel() {

}

function ClickDelete() {

}


//Accept
function AcceptAdd() {

}

function AcceptEdit() {

}

function AcceptDelete() {

}


//Show
function ShowMainButtons() {

}

function ShowAddButtons() {

}

function ShowEditButtons() {

}

function ShowDeleteButtons() {

}

//Hide
function HideAllButtons() {

}

//CancelButtons

function CancelAdd() {

}

function CancelEdit() {

}

function CancelDelete() {

}

//Chosen



//////New

function AddClick() {

    HideMainButons()
    ShowAddButtons()
    SetAddButtons()

    var table = document.getElementById("table")
    var tBody = table.getElementsByTagName("tbody")[0]
    var newRow = document.createElement("tr")

    var head = document.getElementById("headtable")

    var cells = head.cells

    var sizesWidth = []
    var sizesHeight = []
    var placeholders = []
    var allNewInputs = []

    var unitOptions = ['А', 'Б']

    var studentList = []

    let k=0
    while (true) {
        let student = document.getElementById('student-id' + k)
        if (student == null) { break; }
        else {
            studentList.push(document.getElementById('student-id' + k))
            console.log(studentList[k].value)
            k++
        }
            
    }

    for (var cell of cells) {
        sizesWidth.push(cell.clientWidth)
        sizesHeight.push(cell.clientHeight)
        placeholders.push(cell.innerHTML)
    }

    for (var i = 0; i < cells.length; i++) {

        var newTdCell = document.createElement("td")
        newTdCell.style.padding = "0"
        newTdCell.style.background = 'white'
        if (i % cells.length >1 && i % cells.length<=3) {

            var newInput = document.createElement("select")
            newInput.className = "myClass"
            $(document).ready(function () {


                $(".myClass").chosen({ width: "100%", no_results_text : "-"})

            });
            $(document).ready(function () {
                $newHeight = $('th').css('height') 
                $(".chosen-container-single .chosen-single").css('border-radius', '0px')
                $(".chosen-container-single .chosen-single").css('height', $newHeight )                
                

            });

            for (unit of unitOptions) {
                let option = document.createElement('option')
                option.value = unit
                option.innerHTML = unit
                if (i % cells.length == 2) {
                    newInput.options.add(option)
                }
            }

            for (student of studentList) {
                if (i % cells.length == 3) {
                    newInput.options.add(student)
                    console.log('student-opt')
                }
            }

            

            //Styles:
            newInput.style.width = parseInt(sizesWidth[i]) - 1 + "px"
            newInput.style.height = parseInt(sizesHeight[i]) + "px"
            newInput.style.border = "0"
            newInput.style.padding = "0px"
            newInput.style.borderRadius = "0px"
            newInput.style.background = "rgba(100,100, 205, 0.03)"

            newInput.placeholder = placeholders[i]

            newTdCell.appendChild(newInput)

            
            if (i % cells.length == 3) {
                for (student of studentList) {
                    student.hidden = false
                    newInput.options.add(student)
                }
            }
            
            

            
            

        }
        else if (i % cells.length == 1) {

            var newInput = document.createElement("input")
            newInput.maxLength = 3
            newTdCell.appendChild(newInput)
            //
            newInput.style.width = parseInt(sizesWidth[i]) - 1 + "px"
            newInput.style.height = parseInt(sizesHeight[i]) + "px"
            newInput.style.border = "0"
            newInput.style.padding = "8px"
            newInput.style.borderRadius = "0px"
            newInput.style.background = "rgba(100,100, 205, 0.03)"
        }
        if (i == 1) {
            var firstInputCell = newInput
        }
        //
        

        newRow.appendChild(newTdCell)
        allNewInputs.push(newInput)
        
    }
    
    table.getElementsByTagName("tbody")[0].appendChild(newRow)
    firstInputCell.select()


}



function DeleteClick() {

    HideMainButons()
    SetDelButtons()
    ShowDeleteButtons()

    var elems = table.getElementsByTagName('tr');

    var curr = 0

    for (var el of elems) {
        if (curr != 0) {
            var e = document.createElement('td');
            e.style.padding = "0"
            e.style.margin = "0"
            e.style.width = el.offsetHeight - 1 + "px"
            e.style.height = el.offsetHeight - 1 + "px"
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

}

function EditClick() {
    //var inputs = table.getElementsByTagName('input')
    //for (var i of inputs) {
    //    i.type = 'text'
    //}


    var editCells = table.getElementsByTagName('td')
    var inputs = table.getElementsByTagName('input')
    var th = table.getElementsByTagName('th')

    for (var i = 0; i < editCells.length; i++) {
        var inputElement = editCells[i].getElementsByTagName('input')[0]
        inputElement.type = 'text'

        if (i % 7 == 0 || i % 8 == 0) {
            inputElement.value = editCells[i].innerText
        }

        editCells[i].innerHTML = inputElement.outerHTML


        var sizesWidth = []
        var sizesHeight = []


        //editCells[i].style.height = parseInt(document.getElementsByTagName('th')[i].clientHeight) + 'px'
        inputElement.style.border = "0"
        inputElement.style.padding = "8px"
        inputElement.style.borderRadius = "0px"
        inputElement.style.background = "rgba(90,100, 205, 0.05)"


        editCells[i].style.padding = "0px"
        editCells[i].style.margin = "0px"
    }


    HideMainButons()
    ShowEditButtons()
    SetEditButtons(editCells)
}


function SetEditButtons(editCells) {
    var applyButton = document.getElementById("ApplyEditButton")
    applyButton.onclick = ApplyEdit
}

function ShowEditButtons() {
    var applyEditButton = document.getElementById('ApplyEditButton')
    applyEditButton.hidden = false
}

function HideEditButtons() {
    var applyEditButton = document.getElementById('ApplyEditButton')
    var cancelButton = document.getElementById('CancelButton')
    applyEditButton.hidden = true
    cancelButton.hidden = true
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
        cur += 1
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

function ApplyEdit() {
    var editCells = table.getElementsByTagName('td')

    for (var i = 0; i < editCells.length; i++) {
        var inputElement = editCells[i].getElementsByTagName('input')[0]
        inputElement.type = 'hidden'

        editCells[i].innerHTML = inputElement.value + inputElement.outerHTML
        editCells[i].style.padding = '8px'
        editCells[i].style.margin = '8px'


    }
    ShowMainButtons()
    HideEditButtons()
}


function ApplyAdd() {
    var rows = table.getElementsByTagName('tr')
    var lastrowNum = rows.length - 1
    var lastrow = rows.item(lastrowNum)
    var newRow = document.createElement('tr')
    var properties = ['Floor', 'Number', 'Unit', 'FullName']
    var j = 0

    var roomListLastIndex = document.getElementById('roomListLastIndex').value

    var inputFloor = document.createElement('input')


    inputFloor.type = 'hidden'
    inputFloor.name = 'Model.roomList[' + roomListLastIndex + '].' + properties[0]
    inputFloor.value = lastrow.cells[1].childNodes[0].value[0]
    lastrow.cells[0].innerHTML = inputFloor.value[0]
    lastrow.cells[0].appendChild(inputFloor)

    var input = document.createElement('input')
    input.type = 'hidden'


    input.name = 'Model.roomList[' + roomListLastIndex + '].Students[0].' + properties[3]
    input.value = lastrow.cells[3].childNodes[0].value
    lastrow.cells[3].innerHTML = lastrow.cells[3].childNodes[0].value
    lastrow.cells[3].appendChild(input)



    for (var i = 1; i < lastrow.cells.length - 1; i++) {
        var inp = document.createElement('input')
        inp.type = 'hidden'
        inp.name = 'Model.roomList[' + roomListLastIndex + '].' + properties[i]
        inp.value = lastrow.cells[i].childNodes[0].value
        lastrow.cells[i].innerHTML = lastrow.cells[i].childNodes[0].value
        lastrow.cells[i].appendChild(inp)
    }

    

    //for (var i of lastrow.cells) {
    //    var td = document.createElement('td')
    //    var input = document.createElement('input')
    //    input.type = 'hidden'
    //    input.name = 'Model.[' + (lastrowNum - 1) + '].' + properties[j]
    //    j += 1
    //    td.innerHTML = i.childNodes[0].value
    //    input.value = td.innerHTML
    //    td.appendChild(input)
    //    newRow.appendChild(td)
    //}

    //lastrow.remove()
    //table.getElementsByTagName("tbody")[0].appendChild(newRow)

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
    var applyAdd = document.getElementById("ApplyAddButton")
    var applyDelete = document.getElementById("ApplyDeleteButton")
    var cancelBtn = document.getElementById("CancelButton")
    applyAdd.hidden = true
    applyDelete.hidden = true
    cancelBtn.hidden = true

}

function ShowDeleteButtons() {
    var ap = document.getElementById("ApplyDeleteButton")
    var can = document.getElementById("CancelButton")
    ap.hidden = false
    can.hidden = false
}
function ShowAddButtons() {
    var ap = document.getElementById("ApplyAddButton")
    var can = document.getElementById("CancelButton")
    ap.hidden = false
    can.hidden = false
}

function SetDelButtons() {
    var apply = document.getElementById("ApplyDeleteButton")
    apply.onclick = ApplyDelete

    var del = document.getElementById("CancelButton")
    del.onclick = CancelDelete
}

function SetAddButtons() {
    var apply = document.getElementById("ApplyAddButton")
    apply.onclick = ApplyAdd

    var del = document.getElementById("CancelButton")
    del.onclick = CancelAdd
}

function SetNullButtons() {
    var apply = document.getElementById("ApplyAddButton")
    apply.onclick = null

    var deleteBtn = document.getElementById("ApplyDeleteButton")
    deleteBtn.onclick = null

    var del = document.getElementById("CancelButton")
    del.onclick = null
}

function SaveButton() {


}