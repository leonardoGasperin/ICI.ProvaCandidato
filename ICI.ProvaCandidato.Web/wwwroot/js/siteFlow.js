document.addEventListener("DOMContentLoaded", function () {
    onGetDataAsync();
});

function editor(noticia) {
    const data = {
        noticia: {
            refId: 0,
            titulo: document.querySelector('input[name="noticiaTitulo"]').value,
            texto: document.querySelector('textarea[name="noticiaText"]').value,
            usuarioId: 0
        },
        usuario: {
            nome: document.querySelector('input[name="usuarioNome"]').value,
            email: document.querySelector('input[name="usuarioEmail"]').value
        },
        tag: {
            descricao: document.querySelector('input[name="noticiaTag"]').value
        }
    };
}

function excluir(noticiaId) {
    fetch(`https://localhost:5001/api/Noticia/?noticiaId=` + noticiaId, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Erro ao excluir notícia');
        }
    })
    .catch(error => {
        console.error('Erro:', error);
    });
}
document.getElementById('noticiaTable').addEventListener('click', function (event) {
    if (event.target && event.target.tagName === 'SPAN' && event.target.textContent === 'Excluir') {
        var linhaParaExcluir = event.target.closest('tr');
        if (linhaParaExcluir) {
            linhaParaExcluir.remove();
        }
    }
});

function onGetDataAsync() {
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

                const textoExibido = item.texto.length > 72 ? item.texto.substring(0, 72) + '...' : item.texto;
                const tr = document.createElement('tr');
                tr.innerHTML = `
                                <td><div style="cursor: pointer"
                                             onclick="GoToLeitura('tabLeitura', 
                                             '${encodeURIComponent(JSON.stringify(item))}')">
                                                ${item.titulo}
                                    </div></td>
                                    <td>${textoExibido}</td>
                                    <td>${item.usuario.nome}</td>
                                    <td>${item.usuario.email}</td>
                                    <td><span onclick="editor(${encodeURIComponent(JSON.stringify(item))})">Editar</span></td>
                                    <td><span onclick="excluir(${encodeURIComponent(JSON.stringify(item.refId))})">Excluir</span></td>`;
                tabTags.appendChild(tr);
                tr.id = item.refId;
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
                    <span style='word-wrap: break-word;'>${noticia.texto}</span>
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
            if (data.descricao !== null) {
                const tagsDiv = document.getElementById("tagConteiner");
                tagsDiv.innerHTML += `<span class="tag-show">${inputValue}<span>`
            }
            else {
                alert(`Ja existe uma Tag com o nome '${inputValue}'`);
            }
        })
        .catch(error => {
            console.error('Erro:', error);
        });
});

document.getElementById('deleteTagForm').addEventListener('submit', function (event) {
    event.preventDefault();
    const inputValue = document.querySelector('input[name="deleteTag"]').value;
    var canDelete = true;

    fetch('https://localhost:5001/api/Tag' , {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(inputValue)
    })
        .then(response => {
            if (response.status !== 404 && !response.ok) {
                throw new Error('Ocorreu um erro ao tentar excluir a descrição.');
            }
            if (response.status === 404) {
                alert(`Tag '${inputValue}' esta vinculada a uma noticia ou foi não encontrada`);
                canDelete = false
                return;
            }
        })
        .then(data => {
            const itemsExcluidos = document.querySelectorAll('.tag-show');
            itemsExcluidos.forEach(item => {
                if (canDelete && item.textContent === inputValue) {
                    item.remove();
                }
            });
            console.log('Resposta da API:', data);
        })
        .catch(error => {
            console.error('Erro:', error);
        });
});

document.getElementById('createNoticiaForm').addEventListener('submit', function (event) {
    event.preventDefault();
    const data = {
        noticia: {
            refId: 0,
            titulo: document.querySelector('input[name="noticiaTitulo"]').value,
            texto: document.querySelector('textarea[name="noticiaText"]').value,
            usuarioId: 0
        },
        usuario: {
            nome: document.querySelector('input[name="usuarioNome"]').value,
            email: document.querySelector('input[name="usuarioEmail"]').value
        },
        tag: {
            descricao: document.querySelector('input[name="noticiaTag"]').value
        }
    };

    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
    const url = 'https://localhost:5001/api/Noticia';

    fetch(url, requestOptions)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao enviar a requisição.');
            }
            return response.json();
        })
        .then(data => {
            const Noticiatabela = document.getElementById("noticiaTable");
            const textoExibido = data.noticia.texto.length > 72 ? data.noticia.texto.substring(0, 72) + '...' : data.noticia.texto;

            Noticiatabela.innerHTML += `
                <tr data-refid="${data.noticia.refId}">
                <td><div style="cursor: pointer"
                                             onclick="GoToLeitura('tabLeitura',
                                             '${encodeURIComponent(JSON.stringify(data.noticia))}')">
                                                ${data.noticia.titulo}
                                    </div></td>
                                    <td>${textoExibido}</td>
                                    <td>${data.usuario.nome}</td>
                                    <td>${data.usuario.email}</td>
                                    <td><span onclick="editor(${encodeURIComponent(JSON.stringify(data.noticia))})">Editar</span></td>
                                    <td><span onclick="excluir(${encodeURIComponent(JSON.stringify(data.noticia.refId))})">Excluir</span></td>
                </tr>
            `;
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