import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class SampleServiceFields extends ServiceBase {


    constructor() {
        super()
    }

    getFormFields(moreFormControls? : any) {
        var formControls = Object.assign(moreFormControls || {},{
            descricao : new FormControl(),
            tags : new FormControl(),
            telefone : new FormControl(),
            cpf : new FormControl(),
            sampleId : new FormControl(),
            datetime : new FormControl(),
            name : new FormControl(),
            sampleTypeId : new FormControl(),
            age : new FormControl(),
            category : new FormControl(),
            valor : new FormControl(),
            ativo : new FormControl(),
        });
        return new FormGroup(formControls);
    }

    getInfosFields(moreInfosFields? : any, orderByMore = false) {
        var defaultInfosFields = {
                    descricao: { label: 'descricao', type: 'string', isKey: false, list:false   },
                    tags: { label: 'tags', type: 'string', isKey: false, list:false   },
                    telefone: { label: 'telefone', type: 'string', isKey: false, list:true   },
                    cpf: { label: 'cpf', type: 'string', isKey: false, list:true   },
                    sampleId: { label: 'sampleId', type: 'int', isKey: true, list:true   },
                    datetime: { label: 'datetime', type: 'DateTime?', isKey: false, list:true   },
                    name: { label: 'name', type: 'string', isKey: false, list:true   },
                    sampleTypeId: { label: 'sampleTypeId', type: 'int', isKey: false, list:true   },
                    age: { label: 'age', type: 'int?', isKey: false, list:true   },
                    category: { label: 'category', type: 'int?', isKey: false, list:true   },
                    valor: { label: 'valor', type: 'decimal?', isKey: false, list:true   },
                    ativo: { label: 'ativo', type: 'bool?', isKey: false, list:true   },
        };
                return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }
}
