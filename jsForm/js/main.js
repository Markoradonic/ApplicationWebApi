let row = document.createElement('tr');
let list = document.querySelector('.person-list');
let addPersonForm = document.querySelector('#person-form');
let titleValue = document.getElementById('name');
let lastNameValue = document.getElementById('lastName');
let jmbgValue = document.getElementById('jmbg');
let output = '';
let url = "https://localhost:44300/api/Persons";

function renderPost(person) {
    person.data.forEach(element => {
        output += `
        <tr>
        <td class="person-name">${element.name}</td>
        <td>${element.lastName}</td>
        <td>${element.jmbg}</td>
        <td><a href="#" class=" btn btn-danger btn-sm delete" id='${element.id}' >Delete</a>
        <a href="#" class="btn btn-primary btn-sm delete" id='edit' >Edit</a></td>
        </tr>
        `
        list.innerHTML = output;
    });
}
fetch(url)
    .then(res => res.json())
    .then(person => renderPost(person))

list.addEventListener('click', function (e) {
    e.preventDefault();
    let editBtn = e.target.id == "edit";

    if (editBtn) {

        let titleContent = document.querySelector('.person-name').textContent;
        titleValue.value = titleContent;

    }
})


list.addEventListener('click', (e) => {
    e.preventDefault();
    let deleteButton = e.target.id;
    let editButton = e.target.id;


    if (deleteButton) {
        fetch(`${url}/${deleteButton}`, {
                method: 'DELETE',
            })
            .then(res => res.json())
            .then(() => location.reload())
    }
})





// Create Person
//Method: POST

addPersonForm.addEventListener('submit', (e) => {
    e.preventDefault();

    let _data = {
        name: titleValue.value,
        lastName: lastNameValue.value,
        jmbg: jmbgValue.value
    }

    fetch("https://localhost:44300/api/Persons", {
        method: 'POST',
        body: JSON.stringify(_data),
        headers: new Headers({
            'Content-Type': 'application/json'
        })

    });

    // const dataArr = [];
    // dataArr.push(ListOfData)

    // fetch(url)

    //     .then(res => res.json())
    //     .then(data => renderPost(data.ListOfData))



    window.location.reload()
















})