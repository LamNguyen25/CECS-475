// Lam Nguyen
// Assignment 2: Part 2
using System;

namespace HealthPlan_Factory {
    class MainApp {
        static void Main() {
            /* Create an object for each Factory type */
            HMOPlanFactory hmoFactory = new HMOPlanFactory();
            PPOPlanFactory ppoFactory = new PPOPlanFactory();
            ObamaCarePlanFactory obamaCareFactory = new ObamaCarePlanFactory();
            bool done = false;
            /*Get user's input for the plan type */
            while(done == false) {
                Console.WriteLine("Choose a plan type from the following list or any invalid input to exit:");
                Console.WriteLine("\t1 - HMO");
                Console.WriteLine("\t2 - PPO");
                Console.WriteLine("\t3 - ObamaCare");
                Console.Write("Your option? ");

                /* Read user's input and create an object of a health plan type*/
                switch (Convert.ToString(Console.ReadLine())) {
                    case "1":
                        HealthPlan hmoPlan = hmoFactory.GetPlan();
                        Console.WriteLine($"Plan Type: {hmoPlan.GetPlanType}; Anual Charge: ${hmoPlan.Anual_Charge = 645.65}; Deduction Amount: ${hmoPlan.Deduction_Amount = 223.49}");
                        break;
                    case "2":
                        HealthPlan ppoPlan = ppoFactory.GetPlan();
                        Console.WriteLine($"Plan Type: {ppoPlan.GetPlanType}; Anual Charge: ${ppoPlan.Anual_Charge = 567.98}; Deduction Amount: ${ppoPlan.Deduction_Amount = 134.8}");
                        break;
                    case "3":
                        HealthPlan ocPlan = obamaCareFactory.GetPlan();
                        Console.WriteLine($" Plan Type: {ocPlan.GetPlanType}; Anual Charge: ${ocPlan.Anual_Charge = 744.67}; Deduction Amount: ${ocPlan.Deduction_Amount = 321.78}");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!");
                        done = true;
                        break;
                }
            }
            
        }
    }

    /* The 'Product' abstract class*/
    public abstract class HealthPlan {
        /* Anual Charge */
        protected double anualCharge;
        /* Deduction Amount */
        protected double deductionAmount;
        /* Name of plan */
        protected string planType;

        /* Get and set method for anual charge */
        public abstract double Anual_Charge { get; set; }
        /* Get and set method for deduction amount*/
        public abstract double Deduction_Amount { get; set; }
        /* Return the name of the plan type*/
        public abstract String GetPlanType { get; }
    }
    /* Concrete class HMO that extends HealthPlan abstract class */
    public class HMO : HealthPlan {
        /* HMO constructor
        set the planType to "HMO"
        */
        public HMO() {
            planType = "HMO";
        }
        /* @override anual_Charge method */
        public override double Anual_Charge {
            get { return anualCharge; }
            set { anualCharge = value; }
        }
        /* @override deduction_Amount method */
        public override double Deduction_Amount {
            get { return deductionAmount; }
            set { deductionAmount = value; }
        }
        /* @override GetPlanType method */
        public override string GetPlanType => planType;
    }

    /* Concrete class PPO that extends HealthPlan abstract class */
    public class PPO : HealthPlan {
        /* PPO constructor
        set the planType to "HMO"
        */
        public PPO() {
            planType = "PPO";
        }
        /* @override anual_Charge method */
        public override double Anual_Charge {
            get { return anualCharge; }
            set { anualCharge = value; }

        }
        /* @override deduction_Amount method */
        public override double Deduction_Amount {
            get { return deductionAmount; }
            set { deductionAmount = value; }
        }

        /* @override GetPlanType method */
        public override string GetPlanType => planType;
    }

    /* Concrete class ObamaCare that extends HealthPlan abstract class */
    public class ObamaCare : HealthPlan {
        /* ObamaCare constructor
        set the planType to "HMO"
        */
        public ObamaCare() {
            planType = "ObamaCare";
        }

        /* @override anual_Charge method */
        public override double Anual_Charge {
            get { return anualCharge; }
            set { anualCharge = value; }
        }
        /* @override deduction_Amount method */
        public override double Deduction_Amount {
            get { return deductionAmount; }
            set { deductionAmount = value; }
        }
        /* @override GetPlanType method */
        public override string GetPlanType => planType;
    }

    /* Abstract class and declares the factory method */
    public abstract class PlanFactory {
        /* Abstract class return a HealthPlan object */
        public abstract HealthPlan GetPlan();
    }

    /* Generate object of concrete class based on given plan type.*/
    public class HMOPlanFactory : PlanFactory {
        /* @override Method GetPlan return an object of that plan type */
        public override HealthPlan GetPlan() {
            return new HMO();
        }
    }

    public class PPOPlanFactory : PlanFactory {
        /* @override Method GetPlan return an object of that plan type */
        public override HealthPlan GetPlan() {
            return new PPO();
        }
    }

    public class ObamaCarePlanFactory : PlanFactory {
        /* @override Method GetPlan return an object of that plan type */
        public override HealthPlan GetPlan() {
            return new ObamaCare();
        }
    }
}
