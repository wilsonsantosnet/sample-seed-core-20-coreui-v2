import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class SampleDetailServiceFields extends ServiceBase {


    constructor() {
        super()
    }

    getFormFields(moreFormControls? : any) {
        var formControls = Object.assign(moreFormControls || {},{
            name : new FormControl(),
            descricao : new FormControl(),
            data : new FormControl(),
            sampleDetailId : new FormControl(),
            sampleId : new FormControl(),
        });
        return new FormGroup(formControls);
    }

    getInfosFields(moreInfosFields? : any, orderByMore = false) {
        var defaultInfosFields = {
                    name: { label: 'name', type: 'string', isKey: false, list:true   },
                    descricao: { label: 'descricao', type: 'string', isKey: false, list:false   },
                    data: { label: 'data', type: 'DateTime?', isKey: false, list:true   },
                    sampleDetailId: { label: 'sampleDetailId', type: 'int', isKey: true, list:false   },
                    sampleId: { label: 'sampleId', type: 'int', isKey: false, list:true   },
        };
                return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }
}
