import { IQuest } from "./IQuest";

export interface IMasterPackage {
     QuestItems:IQuest[], 
     ClosestItem:IQuest, 
     Score:number,
}