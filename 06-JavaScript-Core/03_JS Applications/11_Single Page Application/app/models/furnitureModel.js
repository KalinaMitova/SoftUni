const furnitureModel = function () {
    const create = function (params) {

        let isValid = validateModel(params);

        if(!isValid) {
            
            return;
        }

        var data = {
            make: params.make,
            model: params.model,
            year: params.year,
            description: params.description,
            price: params.price,
            image: params.image,
            material: params.material
        };

        var url = `appdata/${storage.appKey}/furniture`;

        return requester.post(url, data);
    }

    const validateModel = function (data) {
        try {
            if (!(data.make && data.model &&
                    data.make.length >= 4 &&
                    data.model.length >= 4)) {
                return false;
            }

            if (+data.year < 1950 && +data.year > 2050) {
                return false;
            }

            if (data.description <= 10) {
                return false;
            }

            if (+data.price <= 0) {
                return false;
            }

            if (!data.image) {
                return false;
            }

            return true;
        } catch {
            return false;
        }
    }

    return {
        create
    };
}();