class UI {

    static persons = [];

    static displayPersons() {
        UI.cleanListOnUi();
        UI.displayNumberOfPersons();
        UI.persons.forEach((person) => UI.displayPerson(person));
    }

    static displayPerson(person) {
        let row = document.createElement('tr');
        let list = document.querySelector('.person-list');
        row.innerHTML = `
        <td>${person.name}</td>
        <td>${person.lastName}</td>
        <td>${person.JMBG}</td>
        <td><a href="#" class="btn btn-danger btn-sm delete" onClick="UI.deletePerson('${person.id}')" >Delete</a></td>
        `;

        list.appendChild(row);
    }

    addPersonToLIst(person) {
        UI.persons.push(person);
        UI.displayPersons();
        console.log(UI.persons);
    }

    static displayNumberOfPersons() {
        let numberOfPersonsSpan = document.querySelector('#persons-number');
        numberOfPersonsSpan.innerHTML = UI.persons.length;
    }

    static deletePerson(id) {

        for (let i = 0; i < UI.persons.length; i += 1) {
            if (UI.persons[i].id === id) {
                UI.persons.splice(i, 1);
                console.log(UI.persons);
                console.log(id)
                UI.displayPersons();
                return;
            }
        }
    }


    showAlert(message, className) {
        const div = document.createElement('div');
        div.className = `alert alert-${className}`;
        div.appendChild(document.createTextNode(message));
        const container = document.querySelector('.firstCh');
        const form = document.querySelector('#person-form');
        container.insertBefore(div, form);

        setTimeout(() => document.querySelector('.alert').remove(), 3000);
    }


    clearFields() {
        document.querySelector('#name').value = '';
        document.querySelector('#lastName').value = '';
        document.querySelector('#jmbg').value = '';
    }

    static cleanListOnUi() {
        let list = document.querySelector('.person-list');
        list.innerHTML = "";
    }
}