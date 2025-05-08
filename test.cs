
/// <summary>
/// Lớp DAO cơ sở sử dụng mẫu thiết kế Data Mapper
/// Chuyển đổi dữ liệu từ DataTable/DataRow thành đối tượng DTO
/// </summary>
public abstract class BaseDataMapper<TDto> where TDto : class, new()
{
    protected DatabaseHelper db = new DatabaseHelper();
    
    /// <summary>
    /// Chuyển đổi một DataRow thành đối tượng DTO
    /// </summary>
    protected abstract TDto MapToDto(DataRow row);
    
    /// <summary>
    /// Chuyển đổi DataTable thành danh sách đối tượng DTO
    /// </summary>
    protected virtual List<TDto> MapToList(DataTable dt)
    {
        if (dt == null || dt.Rows.Count == 0)
            return new List<TDto>();
            
        List<TDto> dtoList = new List<TDto>();
        foreach (DataRow row in dt.Rows)
        {
            try 
            {
                dtoList.Add(MapToDto(row));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi chuyển đổi dữ liệu: {ex.Message}");
            }
        }
        return dtoList;
    }
    
    /// <summary>
    /// Truy vấn và chuyển đổi kết quả thành danh sách DTO
    /// </summary>
    protected List<TDto> ExecuteAndMap(string query, Dictionary<string, object> parameters = null)
    {
        DataTable dt = parameters != null 
            ? db.ExecuteQuery(query, parameters) 
            : db.ExecuteQuery(query);
        return MapToList(dt);
    }
    
    /// <summary>
    /// Xử lý an toàn giá trị null từ DataRow
    /// </summary>
    protected T GetValueOrDefault<T>(DataRow row, string columnName, T defaultValue)
    {
        return row[columnName] != DBNull.Value 
            ? (T)Convert.ChangeType(row[columnName], typeof(T)) 
            : defaultValue;
    }
}

