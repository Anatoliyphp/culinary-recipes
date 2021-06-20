import { Injectable } from "@angular/core";
import { RIngridient } from "src/app/core/models/ingridient";
import { RStep } from "src/app/core/models/step";

@Injectable({
    providedIn: 'root'
})
export class AddRecipeService {

    public  steps: RStep[] = [];
    public ingrs: RIngridient[] = [];
    private stepIt: number = 1;
    private ingrsIt: number = 1;
    private deletedSteps: number = 0;
    private deletedIngrs: number = 0;

    AddStep(){
        //this.steps.push({number: this.stepIt, header: "", desc: ""});
        this.stepIt++;
      }
    
    AddIngr(){
        //this.ingrs.push({id: this.ingrsIt, header: "", desc: ""});
        this.ingrsIt++;
    }

    RemoveStep(stepNumber: number)
    {
        if (stepNumber != 1)
        {
            this.steps.splice(stepNumber - 1 - this.deletedSteps, 1);
        }
        else
        {
            this.steps.splice(stepNumber - 1, 1);
        }
        this.deletedSteps++;
    }

    RemoveIngr(id: number)
    {
        if (id != 1)
        {
            this.ingrs.splice(id - 1 - this.deletedIngrs, 1);
        }
        else
        {
            this.ingrs.splice(id - 1, 1);
        }
        this.deletedIngrs++;
    }

}