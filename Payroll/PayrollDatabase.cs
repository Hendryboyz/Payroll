using System;
using System.Collections;
using Payroll.Domain;

namespace Payroll
{
    public class PayrollDatabase
    {
        // error will occur if data structor adopt dictionary
        private static Hashtable _employeeTable = new Hashtable();
        private static Hashtable _memberTable = new Hashtable();

        public static Employee GetEmployee(int empId)
        {
            return _employeeTable[empId] as Employee;
        }

        public static void DeleteEmployee(int empId)
        {
            if (_employeeTable.ContainsKey(empId))
            {
                _employeeTable.Remove(empId);
            }
        }

        public static Employee GetUnionMember(int memberId)
        {
            return _memberTable[memberId] as Employee;
        }

        public static void AddEmployee(Employee employee)
        {
            _employeeTable[employee.EmployeeId] = employee;
        }

        public static void AddUnionMember(int memberId, Employee e)
        {
            _memberTable[memberId] = e;
        }
    }
}
