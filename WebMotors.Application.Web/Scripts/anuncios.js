jQuery(document).ready(function () {

    jQuery('#cmbMarcas').on('change', async function () {
		let id = jQuery(this).find(":selected").val();
        $("#Marca").val(jQuery(this).find(":selected").text())
        let response = await request(`/AnunciosWebMotors/GetDataDropListJson?typeRequest=1&id=${id}`)
        let cmb = $("#cmbModelos")
        cmb.find('option').remove()

        $("#cmbVersoes").find('option').remove()
        renderSelect(cmb, response)
    });

    jQuery('#cmbModelos').on('change', async function () {
        let id = jQuery(this).find(":selected").val();

        let response = await request(`/AnunciosWebMotors/GetDataDropListJson?typeRequest=2&id=${id}`)
        $("#Modelo").val(jQuery(this).find(":selected").text())
        let cmb = $("#cmbVersoes")
        cmb.find('option').remove()
        renderSelect(cmb, response)
    });

    jQuery('#cmbVersoes').on('change', async function () {
      
        $("#Versao").val(jQuery(this).find(":selected").text())
      
    });

    function renderSelect(component, data) {
        component.append($('<option>', {
            value: "",
            text: "Selecione"
        }))
        $.each(data, (i, item) => {
            component.append($('<option>', {
                value: item.Value,
                text: item.Text
            }))
        })
    }

	 function request(url) {
		return new Promise((resolve, reject) => {

			fetch(url, {
				method: 'get' 
			}).then(response => {
				return response.json()
            }).then(data => {
                resolve(data)
            })	
		})
	}

})