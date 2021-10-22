let row = document.createElement('tr');
let list = document.querySelector('.person-list');
let output = '';
let url = "https://localhost:44300/api/Persons";

const renderPost = (person) => {
    person.data.forEach(element => {
        output += `
        <tr>
        <td>${element.name}</td>
        <td>${element.lastName}</td>
        <td>${element.jmbg}</td>
        <td><a href="#" class="btn btn-danger btn-sm delete" onClick="UI.deletePerson('${element.id}')" >Delete</a></td>
        </tr>
        `
        list.innerHTML = output;
    });
}


fetch(url)
    .then(res => res.json())
    .then(person => renderPost(person))