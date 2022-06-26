let app = new Vue({
    el: '#app',
    data: {
        pageTitle: '',
        property: '',
        propertyLoaded: false,
        error: false,
        errorMessage: '',
        detailUrl: `https://localhost:44303/api/Properties/Details/${localStorage.getItem('propertyId')}`,
        propertyDeleted: false,
        referenceValues: [],
        isSexOnly: false,
        isTextOnly: false,
        userMessage: '',
        success: false,
        isLoggedIn: sessionStorage.getItem('isLoggedIn'),
        isAdmin: sessionStorage.getItem('isAdmin'),
    },
    created: async function () {
        this.property = await this.getDetails(this.detailUrl)
        const token = localStorage.getItem('token');
        const headers = {
            headers: {
                Authorization: `Bearer ${token}`
            }
        }
    },
    methods:
    {
        getDetails: async function (apiUrl) {
            let response = '';
            response = await axios.get(apiUrl)
                .then(response => response)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error;
                })
                .finally(() => {
                    this.propertyLoaded = true;
                })
            if (this.error !== true) {
                this.referenceValues = response.data.referenceValues
                this.actOnReferenceValues();
                // this.showAllReferences();
                this.pageTitle = response.data.name;
                return response.data
            }
        },
        getConfirmation: async function (e) {
            var retVal = confirm("Weet u zeker dat u deze bepaling wil verwijderen?");
            if (retVal === true) {
                this.deleteProperty()
            }
        },
        deleteProperty: async function () {
            this.propertyDeleted = false;
            let deleteUrl = `https://localhost:44303/api/Properties?id=${localStorage.getItem('propertyId')}`

            let token = localStorage.getItem('token')
            if (token === null) {
                window.location.href = '/Accounts/Login';
            }
            const headers = {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            };

            await axios.delete(deleteUrl, headers)
                .then(response => response)
                .catch(error => console.log(error))
                .finally(() => this.propertyDeleted = true);

            if (this.error === true) {
                this.userMessage = errorMessage;
            }
            else {
                this.success = true;
                this.userMessage = 'De bepaling werd verwijderd!';
            }

            window.setTimeout(function () {
                window.location.href = 'https://localhost:5001/Properties';
            }, 2000);
        },
        actOnReferenceValues: async function () {
            let isAgeOnly = false;
            let isSexOnly = false;
            for (var refVal of this.referenceValues) {
                if (refVal.sex !== undefined && refVal.maximalAge !== undefined) {
                    isAgeOnly = true;
                    isSexOnly = true;
                }
                else if (refVal.sex === undefined && refVal.maximalAge !== undefined) {
                    isAgeOnly = true;
                }
                else if (refVal.sex !== undefined && refVal.maximalAge === undefined) {
                    isSexOnly = true;
                }
                else this.isTextOnly = true;
            }

            if (isAgeOnly && isSexOnly) {
                this.showAllReferences();
            }
            else if (isAgeOnly) {
                this.showAgeReferences();
            }
            else if (isSexOnly) {
                this.showSexReferences();
            }
            else {
                this.showTextReferences();
            }
        },
        showAllReferences: function () {
            const getUniqueValues = (data, key) => Array.from(new Set(this.referenceValues.map(({ [key]: value }) => value)));

            let allSexes = getUniqueValues(this.referenceValues, 'sex');
            Object.keys(allSexes).forEach(key => {
                if (allSexes[key] === undefined) {
                    allSexes.splice(key, 1);
                }
            })

            let units = getUniqueValues(this.referenceValues, 'unit');

            const table = document.querySelector('#referenceTable');

            let newTable = document.createElement('table');
            newTable.className += ('table table-striped bg-light');

            let tableHead = document.createElement('thead');
            tableHead.className += ('thead-dark');
            //const tableHead = document.querySelector('.thead-dark')

            let tableBody = document.createElement('tbody');
            tableBody.id = 'tbodyRefOnProps';
            //const tableBody = document.querySelector('#tbodyRefOnProps')

            let trH = document.createElement('tr');

            let thH = document.createElement('th');
            thH.innerHTML = 'Maximumleeftijd';
            thH.style.textAlign = 'center';
            trH.append(thH);

            for (var i = 0; i < allSexes.length; i++) {
                let th = document.createElement('th');
                th.innerHTML = `${allSexes[i]} (in ${units[0]})`;
                th.style.textAlign = 'center';
                trH.append(th);
            }
            tableHead.append(trH);

            let listOfAgePeriods = [];

            for (var refVal of this.referenceValues) {
                let agePeriod = `${refVal.maximalAge}${refVal.period.toLowerCase()}`;

                if (!listOfAgePeriods.find(e => e === agePeriod)) {
                    let trB = document.createElement('tr');
                    listOfAgePeriods.push(agePeriod);
                    let td = document.createElement('td');

                    if (agePeriod !== 'undefinedmin') {
                        td.innerHTML = `${agePeriod}`;
                        td.style.textAlign = 'center';
                    }

                    trB.append(td);

                    if (refVal.sex === undefined) {
                        let td = document.createElement('td');
                        td.colSpan = 2;

                        if (refVal.minimumValue === undefined) {
                            td.innerHTML = `< ${refVal.maximumValue}`
                        }
                        else if (refVal.maximumValue === undefined) {
                            td.innerHTML = `> ${refVal.minimumValue}`
                        }
                        else {
                            td.innerHTML = `${refVal.minimumValue} - ${refVal.maximumValue}`;
                        }

                        td.style.textAlign = 'center';
                        trB.append(td);
                        tableBody.append(trB);
                    }
                    else {
                        for (var sex of allSexes) {
                            if (refVal.sex === sex) {
                                let td = document.createElement('td');

                                if (refVal.minimumValue === undefined) {
                                    td.innerHTML = `< ${refVal.maximumValue}`
                                }
                                else if (refVal.maximumValue === undefined) {
                                    td.innerHTML = `> ${refVal.minimumValue}`
                                }
                                else {
                                    td.innerHTML = `${refVal.minimumValue} - ${refVal.maximumValue}`;
                                }

                                td.style.textAlign = 'center';
                                trB.append(td);
                                tableBody.append(trB);
                            }
                        }
                    }

                }
                else {
                    for (sex of allSexes) {
                        if (refVal.sex === sex) {
                            let td = document.createElement('td');

                            if (refVal.minimumValue === undefined) {
                                td.innerHTML = `< ${refVal.maximumValue}`
                            }
                            else if (refVal.maximumValue === undefined) {
                                td.innerHTML = `> ${refVal.minimumValue}`
                            }
                            else {
                                td.innerHTML = `${refVal.minimumValue} - ${refVal.maximumValue}`;
                            }

                            td.style.textAlign = 'center';
                            var lastRow = tableBody.lastElementChild;
                            lastRow.append(td);
                        }
                    }
                }

            }
            newTable.append(tableHead);
            newTable.append(tableBody);
            table.append(newTable);
        },
        showAgeReferences: function () {
            const getUniqueValues = (data, key) => Array.from(new Set(this.referenceValues.map(({ [key]: value }) => value)));
            const table = document.querySelector('#referenceTable');

            let newTable = document.createElement('table');
            newTable.className += ('table table-striped bg-light');

            let tableHead = document.createElement('thead');
            tableHead.className += ('thead-dark');

            let tableBody = document.createElement('tbody');
            tableBody.id = 'tbodyRefOnProps';

            let units = getUniqueValues(this.referenceValues, 'unit');
            let trH = document.createElement('tr');
            let thH1 = document.createElement('th');
            thH1.innerHTML = `Maximumleeftijd`;
            thH1.style.textAlign = 'center';
            trH.append(thH1);

            let thH2 = document.createElement('th');
            thH2.innerHTML = `in ${units[0]}`
            thH2.style.textAlign = 'center';
            trH.append(thH2);


            tableHead.append(trH);

            for (var refVal of this.referenceValues) {
                let agePeriod = `${refVal.maximalAge}${refVal.period.toLowerCase()}`;

                let trB = document.createElement('tr');
                let tdA = document.createElement('td');

                if (agePeriod !== 'undefinedmin') {
                    tdA.innerHTML = `${agePeriod}`;
                    tdA.style.textAlign = 'center';
                }

                trB.append(tdA);

                let tdR = document.createElement('td');

                if (refVal.minimumValue === undefined) {
                    tdR.innerHTML = `< ${refVal.maximumValue}`
                }
                else if (refVal.maximumValue === undefined) {
                    tdR.innerHTML = `> ${refVal.minimumValue}`
                }
                else {
                    tdR.innerHTML = `${refVal.minimumValue} - ${refVal.maximumValue}`;
                }

                tdR.style.textAlign = 'center';
                trB.append(tdR);
                tableBody.append(trB);
            }

            newTable.append(tableHead);
            newTable.append(tableBody);
            table.append(newTable);
        },
        showSexReferences: function () {
            const refDiv = document.querySelector('#referenceTable');
            const refUl = document.createElement('ul');
            refUl.className += ('list-unstyled');

            for (var refVal of this.referenceValues) {
                let refLi = document.createElement('li');

                if (refVal.minimumValue === undefined) {
                    refLi.innerHTML = `${refVal.sex}: < ${refVal.maximumValue} ${refVal.unit}`;
                }
                else if (refVal.maximumValue === undefined) {
                    refLi.innerHTML = `${refVal.sex}: > ${refVal.minimumValue} ${refVal.unit}`;
                }
                else {
                    refLi.innerHTML = `${refVal.sex}: ${refVal.minimumValue} - ${refVal.maximumValue} ${refVal.unit}`;
                }
                refUl.append(refLi);
            }
            refDiv.append(refUl);
        },
        showTextReferences: function () {
            const refDiv = document.querySelector('#referenceTable');
            const refUl = document.createElement('ul');
            refUl.className += ('list-unstyled');

            for (var refVal of this.referenceValues) {
                let refLi = document.createElement('li');

                if (refVal.stringValue !== undefined) {
                    refLi.innerHTML = `${refVal.stringValue}`;
                    refUl.append(refLi);
                }
                else {
                    if (refVal.minimumValue === undefined) {
                        refLi.innerHTML = `< ${refVal.maximumValue} ${refVal.unit}`;
                    }
                    else if (refVal.maximumValue === undefined) {
                        refLi.innerHTML = `> ${refVal.minimumValue} ${refVal.unit}`;
                    }
                    else {
                        refLi.innerHTML = `${refVal.minimumValue} - ${refVal.maximumValue} ${refVal.unit}`;
                    }
                }
                refUl.append(refLi);
            }
            refDiv.append(refUl);
        }
    },
});
