import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class SampleStandartServiceFields extends ServiceBase {


    constructor() {
        super()
    }

    getFormFields(moreFormControls? : any) {
        var formControls = Object.assign(moreFormControls || {},{
            name : new FormControl(),
            sampleStandartId : new FormControl(),
        });
        return new FormGroup(formControls);
    }

    getInfosFields(moreInfosFields? : any, orderByMore = false) {
        var defaultInfosFields = {
                    name: { label: 'name', type: 'string', isKey: false, list:true   },
                    sampleStandartId: { label: 'sampleStandartId', type: 'int', isKey: true, list:false   },
        };
                return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }
}
