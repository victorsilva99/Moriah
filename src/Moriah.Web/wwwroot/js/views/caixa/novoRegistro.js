(() => {
    const campoData = document.getElementById('Data');
    const camposValores  = document.querySelectorAll('#formNovoRegistro input[type=text]');

    formatarCamposValoresMonetarios(camposValores);
    definirDataMaximaParaDataAtual(campoData);

    campoData.addEventListener("input", verificarDiaSelecionado);
})();