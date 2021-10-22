let row = document.createElement('tr');
let list = document.querySelector('.person-list');
let addPersonForm = document.querySelector('#person-form');
let titleValue = document.getElementById('name');
let lastNameValue = document.getElementById('lastName');
let jmbgValue = document.getElementById('jmbg');
let btnSubmit = document.querySelector('.btn');
let output = '';
let url = "https://localhost:44300/api/Persons";

function renderPost(person) {
    person.data.forEach(element => {
        output += `
        <div >
            <tr id=${element.id}>
            <td class="person-name">${element.name}</td>
            <td class="person-lastName">${element.lastName}</td>
            <td class="person-jmbg">${element.jmbg}</td>
            <td><a href="#" class=" btn btn-danger btn-sm delete" id="delete-person" >Delete</a>
            <a href="#" class="btn btn-primary btn-sm delete" id='edit-person' >Edit</a></td>
            </tr>
        </div>
        `
        list.innerHTML = output;
    });
}

fetch(url)
    .then(res => res.json())
    .then(person => renderPost(person))

//DELETE and EDIT 
list.addEventListener('click', (e) => {
    e.preventDefault();
    let deleteButton = e.target.id == 'delete-person'
    let editButton = e.target.id == 'edit-person'
    let id = e.target.parentElement.parentElement.id;


    // delete 
    if (deleteButton) {
        fetch(`${url}/${id}`, {
                method: "DELETE",
            })
            .then(res => res.json())
            .then(() => location.reload())
    }
    // edit
    if (editButton) {
        const parent = e.target.parentElement.parentElement;
        let nameContent = parent.querySelector('.person-name').textContent;
        let lastName = parent.querySelector('.person-lastName').textContent;
        let jmbg = parent.querySelector('.person-jmbg').textContent;

        titleValue.value += nameContent;
        lastNameValue.value += lastName;
        jmbgValue.value += jmbg;
    }

    btnSubmit.addEventListener('click', (e) => {
        e.preventDefault();
        fetch(`${url}/${id}`, {
                method: "PUT",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    name: titleValue.value,
                    lastName: lastNameValue.value,
                    jmbg: jmbgValue.value
                })

            })
            .then(() => location.reload())
    })

})

// Create Person
addPersonForm.addEventListener('submit', (e) => {
    e.preventDefault();

    let _data = {
        name: titleValue.value,
        lastName: lastNameValue.value,
        jmbg: jmbgValue.value
    }

    fetch(`${url}`, {
        method: 'POST',
        body: JSON.stringify(_data),
        headers: new Headers({
            'Content-Type': 'application/json'
        })

    }).then(() => location.reload())
})