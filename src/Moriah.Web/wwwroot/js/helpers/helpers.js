const formatarValor = (valor) => {
    valor = valor.replace(/\D/g, '');
    valor = (valor / 100).toLocaleString('pt-br', {style: 'currency', currency: 'BRL'});
    return valor;
}

const formatarCamposValoresMonetarios = (camposValores) => {
    camposValores.forEach((campo) => {
        campo.addEventListener('input', () => {
            campo.value = formatarValor(campo.value);
        });
    });
};

const definirDataMaximaParaDataAtual = (campoData) => {
    const dataAtual = moment().format().split('T');
    campoData.setAttribute('max', dataAtual[0]);
}

const verificarDiaSelecionado = (event) => {
    let dataSelecionada = new Date(event.target.value);
    if (dataSelecionada.getDay() === 6) {
        notyf.open({
            type: 'info',
            message: 'O dia selecionado cai em um domingo, confirme a data antes de salvar o registro'
        });
    }
}