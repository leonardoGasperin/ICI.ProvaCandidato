document.addEventListener("DOMContentLoaded", function () {
    minhaFuncao();
});

function minhaFuncao() {
    fetch("https://localhost:5001/api/Tag")
        .then(response => response.json())
        .then(data => {
            const tabTags = document.getElementById("tagConteiner");
            data.forEach(function (item) {
                tabTags.innerHTML += `<span class="tag-show">${item.descricao}<span>`;
            });
        })
    fetch("https://localhost:5001/api/Noticia")
        .then(response => response.json())
        .then(data => {
            const tabTags = document.getElementById("noticiaTable");
            data.forEach(function (item) {
                const tr = document.createElement('tr');
                tr.innerHTML = `<td><div style="cursor: pointer"
                                             onclick="GoToLeitura('tabLeitura', 
                                             '${encodeURIComponent(JSON.stringify(item))}')">
                                                ${item.titulo}
                                    </div></td>
                                    <td>${item.texto.substring(0, 75 - 3) + '...'}</td>
                                    <td>${item.usuario.nome}</td>
                                    <td>${item.usuario.email}</td>`;
                tabTags.appendChild(tr);
            });
        })
}

function GoToLeitura(tabid, item) {
    document.getElementById("tabNoticias").classList.remove('active');
    document.getElementById("noticia-btn").classList.remove('active');
    document.getElementById("tabNoticias").style.display = 'none';
    document.getElementById("tabLeitura").classList.add('active');
    document.getElementById("leitura-btn").classList.add('active');
    document.getElementById("tabLeitura").style.display = 'block';

    const noticia = JSON.parse(decodeURIComponent(item));
    let prep = `
            <div class="leitura-model">
                    <span onclick="GoToLeitura('tabLeitura')"><b>Titulo: </b>${noticia.titulo}</span></td>
                    <div>
                        <span><b>Autor: </b>${noticia.usuario.nome}</span>
                        <span><b>Contato: </b>${noticia.usuario.email}</span>
                    </div>
                    <hr style="color: black; width: 30rem;">
                    <span>${noticia.texto}</span>
            </div>
        `
    const leituraDiv = document.getElementById('leituraConteiner');
    leituraDiv.innerHTML = prep;
}

document.getElementById('createTagForm').addEventListener('submit', function (event) {
    event.preventDefault();
    const inputValue = document.querySelector('input[name="createTag"]').value;
    const formData = {
        descricao: inputValue
    };

    fetch('https://localhost:5001/api/Tag', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao enviar os dados.');
            }
            return response.json();
        })
        .then(data => {
            const tagsDiv = document.getElementById("tagConteiner");
            tagsDiv.innerHTML += `<span class="tag-show">${inputValue}<span>`
            console.log('Resposta da API:', data);
        })
        .catch(error => {
            console.error('Erro:', error);
        });
});

document.getElementById('deleteTagForm').addEventListener('submit', function (event) {
    event.preventDefault();
    const inputValue = document.querySelector('input[name="deleteTag"]').value;


    fetch('https://localhost:5001/api/Tag' , {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(inputValue)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Ocorreu um erro ao tentar excluir a descrição.');
            }
            if (response.status === 204) {
                console.log('Descrição excluída com sucesso.');
                return;
            }
        })
        .then(data => {
            const itemsExcluidos = document.querySelectorAll('.tag-show'); // Substitua '.item' pela classe real dos itens
            itemsExcluidos.forEach(item => {
                if (item.textContent === inputValue) {
                    item.remove();
                }
            });
            console.log('Resposta da API:', data);
        })
        .catch(error => {
            console.error('Erro:', error);
        });
});

document.querySelectorAll('.tabs button').forEach(btn => {
    btn.addEventListener('click', function () {
        const target = event.target;
        if (target.tagName === 'BUTTON' && target.getAttribute('data-target')) {

            document.querySelectorAll('.tabs button').forEach(btn => {
                btn.classList.remove('active');
            });
            this.classList.add('active');

            const targetId = this.getAttribute('data-target');
            document.querySelectorAll('.tab-content .tab-pane').forEach(tab => {
                tab.classList.remove('active');
            });
            const targetTab = document.querySelector(targetId);
            targetTab.classList.add('active');
            document.querySelectorAll('.tab-content .tab-pane').forEach(tab => {
                tab.style.display = (tab === targetTab) ? 'block' : 'none';
            });
        }
    });
});