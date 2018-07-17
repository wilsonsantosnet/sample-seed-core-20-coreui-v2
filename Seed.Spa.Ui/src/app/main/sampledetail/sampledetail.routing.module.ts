import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SampleDetailComponent } from './sampledetail.component';
import { SampleDetailEditComponent } from './sampledetail-edit/sampledetail-edit.component';
import { SampleDetailDetailsComponent } from './sampledetail-details/sampledetail-details.component';
import { SampleDetailCreateComponent } from './sampledetail-create/sampledetail-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "SampleDetail" }, component: SampleDetailComponent },
            { path: 'edit/:id', data : { title : "SampleDetail" } ,component: SampleDetailEditComponent },
            { path: 'details/:id', data : { title : "SampleDetail" }, component: SampleDetailDetailsComponent },
            { path: 'create', data : { title : "SampleDetail" }, component: SampleDetailCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class SampleDetailRoutingModule {
}